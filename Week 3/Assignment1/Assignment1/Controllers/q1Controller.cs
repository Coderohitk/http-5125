using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q1Controller : ControllerBase
    {
        /// <summary>
        /// This method returns a welcome message with small intro
        /// </summary>
        /// <returns>A welcome message string</returns>
        /// <example>
        /// GET : http://localhost:xx/api/q1/welcome 
        /// GET : http://localhost:xx/api/q1/intro
        /// </example>
        [HttpGet(template: "welcome")]
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
