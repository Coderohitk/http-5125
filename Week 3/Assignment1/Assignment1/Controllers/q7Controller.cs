using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q7Controller : ControllerBase
    {/// <summary>
     /// This method gives current date adjusted by given days
     /// </summary>
     /// <param name="days">the number of days to adjust in current date</param>
     /// <returns>date as a string in yyyy-MM-dd</returns>
     /// <example>
     /// GET: http://localhost:xx/api/q7/timemachine?days=1
     /// GET: http://localhost:xx/api/q7/timemachine?days=-1
     /// </example>
        [HttpGet(template: "timemachine")]

        public string TimeMachine([FromQuery] int days)
        {
            DateTime currentDate = DateTime.Today;
            DateTime adjustDate = currentDate.AddDays(days);
            return adjustDate.ToString("yyyy-MM-dd");
        }
    }
}
