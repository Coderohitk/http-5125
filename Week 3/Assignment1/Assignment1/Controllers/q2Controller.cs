using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q2Controller : ControllerBase
    {
        [HttpGet(template: "greeting")]
        public string Greeting(string name)
        {
            return $"Hi  {name} !";
        }
    }
}
