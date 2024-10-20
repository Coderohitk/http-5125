using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C__Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1Controller : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collision"></param>
        /// <param name="delivered"></param>
        /// <returns></returns>
        [HttpPost(template: "Delivedroid")]
        [Consumes("application/x-www-form-urlencoded")]
        public int Deliverdroid([FromForm] int collision, [FromForm] int delivered)
        {
            int total = (delivered * 50) + (collision * -10);
            if (delivered > collision)
            {
                total = total + 500;
            }
            return total;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="large"></param>
        /// <param name="small"></param>
        /// <returns></returns>
        [HttpPost(template: "CupcakesParty")]
        [Consumes("application/x-www-form-urlencoded")]
        public int Cupcakes([FromForm] int large, [FromForm] int small)
        {
            int total = (large * 8) + (small * 3);
            int remaining = total - 28;
            return remaining;
        }
    }
}

