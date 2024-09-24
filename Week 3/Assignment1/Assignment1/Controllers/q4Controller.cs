using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q4Controller : ControllerBase
    {
        [HttpPost(template:"knockknock")]
        public string KnockKnock() {
            return"Who's there?";
        }
        [HttpPost(template: "knockknock2")]
        public string KnockKnock2()
        {

            return "I am here";
        }

    }
}
