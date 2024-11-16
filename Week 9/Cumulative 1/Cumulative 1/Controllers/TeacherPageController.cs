using Cumulative_1.Models;
using Cumulative_1.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cumulative_1.Controllers
{
    public class TeacherPageController : Controller
    {
        // Currently relying on the API to retrieve author information
        private readonly TeacherAPIController _api;

        public TeacherPageController(TeacherAPIController api)
        {
            _api = api;
        }

        // GET: TeacherPage/List
        // Add parameters for StartDate and EndDate to search by hire date range
        public IActionResult List(DateTime? StartDate, DateTime? EndDate)
        {
            // Pass the Hire Date range to the API
            List<Teacher> Teachers = _api.ListTeachers(StartDate, EndDate);
            return View(Teachers);
        }

        // GET: TeacherPage/Show/{id}
        //public IActionResult Show(int id)
        //{
        //    Teacher SelectedTeacher = _api.FindTeacher(id);
        //    return View(SelectedTeacher);
        //}
        public IActionResult Show(int id)
        {
            // Validate the ID input (e.g., ID should be a positive integer)
            if (id <= 0)
            {
                ViewBag.ErrorMessage = "Invalid Teacher ID. Please provide a valid ID.";
                return View("Error"); // Render the Error view
            }

            // Retrieve the teacher data using the TeacherAPIController
            var selectedTeacher = _api.FindTeacher(id);

            // Check if the teacher exists
            if (selectedTeacher == null)
            {
                ViewBag.ErrorMessage = "The specified teacher does not exist. Please check the Teacher ID.";
                return View("Error"); // Render the Error view
            }

            // Retrieve the list of course names taught by this teacher
            var teacherCourses = _api.GetCoursesByTeacher(id);

            // Check if the courses exist (optional, in case GetCoursesByTeacher fails)
            if (teacherCourses == null || teacherCourses.Count == 0)
            {
                ViewBag.ErrorMessage = $"No courses found for the teacher with ID {id}.";
                return View("Error"); // Render the Error view
            }

            // Create the ViewModel and pass the Teacher and their Courses
            var viewModel = new TeacherCoursesViewModel
            {
                Teacher = selectedTeacher,
                Courses = teacherCourses
            };

            // Return the view with the ViewModel
            return View(viewModel);
        }


    }
}
