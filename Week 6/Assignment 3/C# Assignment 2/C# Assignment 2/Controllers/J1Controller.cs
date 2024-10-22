using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C__Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1Controller : ControllerBase
    {
        /// <summary>
        /// Calculates total Score according to package delivered and collisions
        /// </summary>
        /// <param name="collision">the number of collisions</param>
        /// <param name="delivered">the number of delivered</param>
        /// <returns>the total score required/returns>
        /// <example>
        ///  POST: api/J1/Delivedroid
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// Post data: Collisions=2&Deliveries=5
        /// ->730
        /// POST: api/J1/Delivedroid
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// Post data: Collisions=10&Deliveries=0
        /// ->-100
        /// POST: api/J1/Delivedroid
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// Post data: Collisions=3&Deliveries=2
        /// ->70
        /// </example>
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
        /// 2022 J1 Calculates the remaning cupcakes after giving to class
        /// </summary>
        /// <param name="large">The number of large box</param>
        /// <param name="small">the number of small box</param>
        /// <returns>returns the remaining cupcakes</returns>
        /// <example>
        /// POST: api/J1/CupcakesParty
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// Post data: large=2&small=5
        /// ->3
        /// POST: api/J1/CupcakesParty
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// Post data: large=2&small=4
        /// ->0
        /// </example>
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

