using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q7Controller : ControllerBase
    {
        [HttpGet(template: "timemachine")]

        public string TimeMachine([FromQuery] int days)
        {
            DateTime currentDate= DateTime.Today;
            DateTime adjustDate= currentDate.AddDays(days);
            return adjustDate.ToString("yyyy-MM-dd");
        }
    }
}
