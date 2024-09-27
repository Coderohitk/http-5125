using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q4Controller : ControllerBase
    {/// <summary>
     /// this method gives reply to knock knock
     /// </summary>
     /// <returns>returns a string </returns>
     /// <example>
     /// POST : http://localhost:xx/api/q4/knockknock
     /// POST : http://localhost:xx/api/q4/knockknock2
     /// </example>
        [HttpPost(template: "knockknock")]
        public string KnockKnock()
        {
            return "Who's there?";
        }
        [HttpPost(template: "knockknock2")]
        public string KnockKnock2()
        {

            return "I am here";
        }
    }
}
