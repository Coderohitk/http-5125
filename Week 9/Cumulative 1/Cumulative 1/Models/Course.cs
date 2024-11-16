using Microsoft.AspNetCore.Mvc;

namespace Cumulative_1.Models
{
    public class Course : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
