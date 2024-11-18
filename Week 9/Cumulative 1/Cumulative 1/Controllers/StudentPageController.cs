using Cumulative_1.Models;
using Cumulative_1.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Cumulative_1.Controllers
{

    public class StudentPageController : Controller
    {
        // currently relying on the API to retrieve author information
        // this is a simplified example. In practice, both the AuthorAPI and AuthorPage controllers
        // should rely on a unified "Service", with an explicit interface
        private readonly StudentAPIController _api;

        public StudentPageController(StudentAPIController api)
        {
            _api = api;
        }

        //GET : AuthorPage/List
        public IActionResult List()
        {
            List<Student> Students = _api.ListStudent();
            return View(Students);
        }

        //GET : AuthorPage/Show/{id}
        public IActionResult Show(int id)
        {
            Student SelectedStudent = _api.FindStudent(id);
            return View(SelectedStudent);
        }

    }
}
