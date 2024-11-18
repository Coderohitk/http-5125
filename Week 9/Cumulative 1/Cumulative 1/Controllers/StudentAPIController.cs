using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cumulative_1.Models;
using System;
using MySql.Data.MySqlClient;

namespace Cumulative_1.Controllers
{
    [Route("api/Student")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly SchooldbContext _context;
        // dependency injection of database context
        public StudentAPIController(SchooldbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route(template: "listStudents")]
        public List<Student> ListStudent()
        {
            List<Student> Students = new List<Student>();
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "Select * from students";
                Command.Prepare();
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    while (ResultSet.Read())
                    {
                        int id = Convert.ToInt32(ResultSet["studentid"]);
                        string FirstName = ResultSet["studentfname"].ToString();
                        string LastName = ResultSet["studentlname"].ToString();
                        string StudentNumber = ResultSet["studentnumber"].ToString();
                        DateTime EnrolDate = Convert.ToDateTime(ResultSet["enroldate"]);
                        Student CurrentStudent = new Student()
                        {
                            StudentId = id,
                            StudentFName = FirstName,
                            StudentLName = LastName,
                            EnrollDate = EnrolDate,
                            StudentNumber = StudentNumber,

                        };

                        Students.Add(CurrentStudent);

                    }
                }

            }
            return Students;
        }
        [HttpGet]
        [Route(template: "FindStudent/{id}")]
        public Student FindStudent(int id)
        {

            //Empty Author
            Student SelectedStudents = new Student();

            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();

                // @id is replaced with a 'sanitized' id
                Command.CommandText = "Select * from students WHERE studentid = @id";
                Command.Parameters.AddWithValue("@id", id);

                // Gather Result Set of Query into a variable
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    //Loop Through Each Row the Result Set
                    while (ResultSet.Read())
                    {
                        //Access Column information by the DB column name as an index
                        int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                        string FirstName = ResultSet["studentfname"].ToString();
                        string LastName = ResultSet["studentlname"].ToString();
                        string StudentNumber = ResultSet["studentnumber"].ToString();
                        DateTime EnrolDate = Convert.ToDateTime(ResultSet["enroldate"]);


                        SelectedStudents.StudentId = StudentId;
                        SelectedStudents.StudentFName = FirstName;
                        SelectedStudents.StudentLName = LastName;
                        SelectedStudents.EnrollDate = EnrolDate;
                        SelectedStudents.StudentNumber = StudentNumber;
                                           }
                }
            }


            //Return the final list of author names
            return SelectedStudents;
        }


    }
}
