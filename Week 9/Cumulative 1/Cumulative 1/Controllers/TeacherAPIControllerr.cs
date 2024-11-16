using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cumulative_1.Models;
using System;
using MySql.Data.MySqlClient;

namespace Cumulative_1.Controllers
{
    [Route("api/Teacher")]
    [ApiController]
    public class TeacherAPIController : ControllerBase
    {
        private readonly SchooldbContext _context;
        // dependency injection of database context
        public TeacherAPIController(SchooldbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Returns a list of Authors in the system
        /// </summary>
        /// <example>
        /// GET api/Author/ListAuthors -> [{"AuthorId":1,"AuthorFname":"Brian", "AuthorLName":"Smith"},{"AuthorId":2,"AuthorFname":"Jillian", "AuthorLName":"Montgomery"},..]
        /// </example>
        /// <returns>
        /// A list of author objects 
        /// </returns>
        [HttpGet]
        [Route(template: "ListTeachers")]
        public List<Teacher> ListTeachers(DateTime? StartDate = null, DateTime? EndDate = null)
        {
            List<Teacher> Teachers = new List<Teacher>();

            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                MySqlCommand Command = Connection.CreateCommand();

                // Base SQL query
                string query = "SELECT * FROM teachers INNER JOIN courses ON teachers.teacherid = courses.teacherid";

                // Add hire date range condition if applicable
                bool hasConditions = false;
                if (StartDate.HasValue && EndDate.HasValue)
                {
                    query += " WHERE hiredate BETWEEN @startDate AND @endDate";
                    Command.Parameters.AddWithValue("@startDate", StartDate.Value);
                    Command.Parameters.AddWithValue("@endDate", EndDate.Value);
                    hasConditions = true;
                }

                Command.CommandText = query;
                Command.Prepare();

                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    Dictionary<int, Teacher> teacherDict = new Dictionary<int, Teacher>();

                    while (ResultSet.Read())
                    {
                        int Id = Convert.ToInt32(ResultSet["teacherid"]);
                        string FirstName = ResultSet["teacherfname"].ToString();
                        string LastName = ResultSet["teacherlname"].ToString();
                        string TeacherEmpNu = ResultSet["employeenumber"].ToString();
                        DateTime TeacherHireDate = Convert.ToDateTime(ResultSet["hiredate"]);
                        string TeacherSalary = ResultSet["salary"].ToString();
                        string CourseName = ResultSet["coursename"].ToString();

                        if (!teacherDict.ContainsKey(Id))
                        {
                            teacherDict[Id] = new Teacher()
                            {
                                TeacherId = Id,
                                TeacherFName = FirstName,
                                TeacherLName = LastName,
                                TeacherHireDate = TeacherHireDate,
                                TeacherSalary = TeacherSalary,
                                TeacherEmpNu = TeacherEmpNu,
                                CourseNames = new List<string>()
                            };
                        }
                        teacherDict[Id].CourseNames.Add(CourseName);
                    }

                    Teachers.AddRange(teacherDict.Values);
                }
            }

            return Teachers;
        }

        //public List<Teacher> ListTeachers(string SearchKey = null)
        //{
        //    // Create an empty list of Authors
        //    List<Teacher> Teachers = new List<Teacher>();

        //    // 'using' will close the connection after the code executes
        //    using (MySqlConnection Connection = _context.AccessDatabase())
        //    {
        //        Connection.Open();
        //        //Establish a new command (query) for our database
        //        MySqlCommand Command = Connection.CreateCommand();

        //        //SQL QUERY
        //        string query = "select * from teachers INNER JOIN  courses ON teachers.teacherid=courses.teacherid";
        //        if (SearchKey != null)
        //        {
        //            query += " where lower(teacherfname) like @key or lower(teacherlname) like @key or lower(concat(teacherfname,' ',teacherlname)) like @key";
        //            Command.Parameters.AddWithValue("@key", $"%{SearchKey}%");
        //        }
        //        Command.CommandText = query;
        //        Command.Prepare();

        //        // Gather Result Set of Query into a variable
        //        using (MySqlDataReader ResultSet = Command.ExecuteReader())
        //        {
        //            //Loop Through Each Row the Result Set
        //            while (ResultSet.Read())
        //            {
        //                //Access Column information by the DB column name as an index
        //                int Id = Convert.ToInt32(ResultSet["teacherid"]);
        //                string FirstName = ResultSet["teacherfname"].ToString();
        //                string LastName = ResultSet["teacherlname"].ToString();
        //                string TeacherEmpNu = ResultSet["employeenumber"].ToString();

        //                DateTime TeacherHireDate = Convert.ToDateTime(ResultSet["hiredate"]);
        //                string TeacherSalary = ResultSet["salary"].ToString();
        //                string CourseName = ResultSet["coursename"].ToString();

        //                //short form for setting all properties while creating the object
        //                Teacher CurrentTeacher = new Teacher()
        //                {
        //                    TeacherId = Id,
        //                    TeacherFName = FirstName,
        //                    TeacherLName = LastName,
        //                    TeacherHireDate = TeacherHireDate,
        //                    TeacherSalary = TeacherSalary,
        //                    TeacherEmpNu = TeacherEmpNu,
        //                    CourseName=CourseName
        //                };

        //                Teachers.Add(CurrentTeacher);

        //            }
        //        }
        //    }


        //    //Return the final list of authors
        //    return Teachers;
        //}


        /// <summary>
        /// Returns an author in the database by their ID
        /// </summary>
        /// <example>
        /// GET api/Author/FindAuthor/3 -> {"AuthorId":3,"AuthorFname":"Sam","AuthorLName":"Cooper"}
        /// </example>
        /// <returns>
        /// A matching author object by its ID. Empty object if Author not found
        /// </returns>
        [HttpGet]
        [Route(template: "FindTeacher/{id}")]
        public Teacher FindTeacher(int id)
        {

            //Empty Author
            Teacher SelectedTeacher = new Teacher();

            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();

                // @id is replaced with a 'sanitized' id
                Command.CommandText = "SELECT teachers.*, courses.courseName FROM courses INNER JOIN teachers ON teachers.teacherId = courses.teacherId WHERE teachers.teacherId = @id";
                Command.Parameters.AddWithValue("@id", id);

                // Gather Result Set of Query into a variable
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    //Loop Through Each Row the Result Set
                    while (ResultSet.Read())
                    {
                        //Access Column information by the DB column name as an index
                        int Id = Convert.ToInt32(ResultSet["teacherid"]);
                        string FirstName = ResultSet["teacherfname"].ToString();
                        string LastName = ResultSet["teacherlname"].ToString();
                        string TeacherEmpNu = ResultSet["employeenumber"].ToString();

                        DateTime TeacherHireDate = Convert.ToDateTime(ResultSet["hiredate"]);
                        string TeacherSalary = ResultSet["salary"].ToString();
                        string CourseName = ResultSet["coursename"].ToString();

                        SelectedTeacher.TeacherId = Id;
                        SelectedTeacher.TeacherFName = FirstName;
                        SelectedTeacher.TeacherLName = LastName;
                        SelectedTeacher.TeacherSalary = TeacherSalary;
                        SelectedTeacher.TeacherHireDate = TeacherHireDate;
                        SelectedTeacher.TeacherEmpNu = TeacherEmpNu;
                        //SelectedTeacher.CourseName = CourseName;

                    }
                }
            }


            //Return the final list of author names
            return SelectedTeacher;
        }
        [HttpGet]
        [Route("GetCoursesByTeacher/{id}")]
        public List<string> GetCoursesByTeacher(int id)
        {
            List<string> courses = new List<string>();

            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "SELECT CourseName FROM courses WHERE TeacherId = @id";
                Command.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    while (ResultSet.Read())
                    {
                        string courseName = ResultSet["CourseName"].ToString();
                        courses.Add(courseName);
                    }
                }
            }

            return courses;
        }

    }
}   