using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q1Controller : ControllerBase
    {
        [HttpGet(template:"welcome")]
        public string Welcome()
        {
            return "Welcome to 5125";
        }
        [HttpGet(template: "intro")]
        public string Intro()
        {
            return "HI my name is rohit christine";
        }
    }
}
