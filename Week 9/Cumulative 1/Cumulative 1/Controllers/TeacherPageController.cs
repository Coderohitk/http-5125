using Cumulative_1.Models;
using Cumulative_1.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Cumulative_1.Controllers
{

    public class TeacherPageController : Controller
    {
        // currently relying on the API to retrieve author information
        // this is a simplified example. In practice, both the AuthorAPI and AuthorPage controllers
        // should rely on a unified "Service", with an explicit interface
        private readonly TeacherAPIController _api;

        public TeacherPageController(TeacherAPIController api)
        {
            _api = api;
        }

        //GET : AuthorPage/List
        public IActionResult List()
        {
            List<Teacher> Teachers = _api.ListTeachers();
            return View(Teachers);
        }

        //GET : AuthorPage/Show/{id}
        public IActionResult Show(int id)
        {
            Teacher SelectedTeacher = _api.FindTeacher(id);
            return View(SelectedTeacher);
        }

    }
}
