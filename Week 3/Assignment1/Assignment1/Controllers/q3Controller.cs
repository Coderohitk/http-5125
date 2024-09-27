using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q3Controller : ControllerBase
    {/// <summary>
     /// This method give cube of given number
     /// </summary>
     /// <param name="number">the number integer to cube</param>
     /// <returns>return a cube value of the given integer</returns>
     /// <example>
     /// GET : http://localhost:xx/api/q3/cube/4
     /// GET : http://localhost:xx/api/q3/cube/-4
     /// GET : http://localhost:xx/api/q3/cube/10
     /// </example>
        [HttpGet(template: "cube/{number}")]
        public double Cube(int number)
        {
            double result = Math.Pow(number, 3);
            return result;
        }
    }
}
