using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q6Controller : ControllerBase
    {/// <summary>
     /// This method give area of the hexagon with given side
     /// </summary>
     /// <param name="side">side of the hexagon</param>
     /// <returns>returns area</returns>
     /// <example>
     /// GET: http://localhost:xx/api/q6/hexagon?side=1
     /// GET: http://localhost:xx/api/q6/hexagon?side=1.5
     /// GET http://localhost:xx/api/q6/hexagon?side=20
     /// </example>
        [HttpGet(template: "hexagon")]
        public double Hexagon(double side)
        {
            double result = (3 * Math.Sqrt(3) / 2) * Math.Pow(side, 2);
            return result;
        }
    }
}
