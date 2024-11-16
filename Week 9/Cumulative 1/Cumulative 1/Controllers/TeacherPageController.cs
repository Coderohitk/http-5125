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
            // Retrieve the teacher data using the TeacherAPIController
            Teacher SelectedTeacher = _api.FindTeacher(id);

            // Retrieve the list of course names taught by this teacher
            List<string> TeacherCourses = _api.GetCoursesByTeacher(id);

            // Create the ViewModel and pass the Teacher and their Courses
            TeacherCoursesViewModel viewModel = new TeacherCoursesViewModel
            {
                Teacher = SelectedTeacher,
                Courses = TeacherCourses
            };

            // Return the view with the ViewModel
            return View(viewModel);
        }
    }
}
