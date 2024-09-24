using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q3Controller : ControllerBase
    {
        [HttpGet(template: "cube/{number}")]
        public double Cube(int number)
        {
           double  result = Math.Pow(number,3);
            return result;
        }
    }
}
