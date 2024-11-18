﻿using Cumulative_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Cumulative_1.Controllers
{
    [Route("api/Course")]
    [ApiController]
    public class CourseAPIController : ControllerBase
    {
        private readonly SchooldbContext _context;
        // dependency injection of database context
        public CourseAPIController(SchooldbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route(template: "listCourse")]
        public List<Course> ListCourse()
        {
            List<Course> Courses = new List<Course>();
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "Select * from courses";
                Command.Prepare();
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    while (ResultSet.Read())
                    {
                        int Couseid = Convert.ToInt32(ResultSet["courseid"]);
                        int teacherId = Convert.ToInt32(ResultSet["teacherid"]);
                        string CourseCode = ResultSet["coursecode"].ToString();
                        string CourseName = ResultSet["coursename"].ToString();
                        DateTime StartDate = Convert.ToDateTime(ResultSet["startdate"]);
                        DateTime FinishDate = Convert.ToDateTime(ResultSet["finishdate"]);

                        Course CurrentCourse = new Course()
                        {
                            courseId = Couseid,
                            teacherid = teacherId,
                            coursecode = CourseCode,
                            coursename = CourseName,
                            startdate = StartDate,
                            finishdate = FinishDate

                        };

                        Courses.Add(CurrentCourse);

                    }
                }

            }
            return Courses;
        }
            [HttpGet]
            [Route(template: "FindCourse/{id}")]
            public Course FindCourse(int id)
            {

                //Empty Author
                Course SelectedCourse = new Course();

                // 'using' will close the connection after the code executes
                using (MySqlConnection Connection = _context.AccessDatabase())
                {
                    Connection.Open();
                    //Establish a new command (query) for our database
                    MySqlCommand Command = Connection.CreateCommand();

                    // @id is replaced with a 'sanitized' id
                    Command.CommandText = "Select * from courses WHERE courseid = @id";
                    Command.Parameters.AddWithValue("@id", id);

                    // Gather Result Set of Query into a variable
                    using (MySqlDataReader ResultSet = Command.ExecuteReader())
                    {
                        //Loop Through Each Row the Result Set
                        while (ResultSet.Read())
                        {
                        //Access Column information by the DB column name as an index
                        int Couseid = Convert.ToInt32(ResultSet["courseid"]);
                        int teacherId = Convert.ToInt32(ResultSet["teacherid"]);
                        string CourseCode = ResultSet["coursecode"].ToString();
                        string CourseName = ResultSet["coursename"].ToString();
                        DateTime StartDate = Convert.ToDateTime(ResultSet["startdate"]);
                        DateTime FinishDate = Convert.ToDateTime(ResultSet["finishdate"]);

                        SelectedCourse.courseId = Couseid;
                        SelectedCourse.teacherid = teacherId;
                        SelectedCourse.coursecode = CourseCode;
                        SelectedCourse.coursename = CourseName;
                        SelectedCourse.startdate = StartDate;
                        SelectedCourse.finishdate = FinishDate;
                            //SelectedTeacher.CourseName = CourseName;

                        }
                    }
                }


                //Return the final list of author names
                return SelectedCourse;
            }

        }


    }
