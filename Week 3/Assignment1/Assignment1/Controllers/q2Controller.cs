using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q2Controller : ControllerBase
    {/// <summary>
     /// This method gives greeting message for given name
     /// </summary>
     /// <param name="name">the name to great</param>
     /// <returns>A greeting message</returns>
     /// <example>
     /// GET : http://localhost:xx/api/q2/greeting?name=Gary
     /// GET : http://localhost:xx/api/q2/greeting?name=Ren%C3%A9e
     /// </example>
        [HttpGet(template: "greeting")]
        public string Greeting(string name)
        {
            return $"Hi  {name} !";
        }
    }
}
