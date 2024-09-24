using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q5Controller : ControllerBase
    {
        [HttpPost(template:"secret")]
        public string ScretWord([FromBody] int secret)
        {
            return $"Shh.. the secret is {secret}";
        }

    
}
}
