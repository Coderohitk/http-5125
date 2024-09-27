using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q5Controller : ControllerBase
    {/// <summary>
     /// this give a secret integer
     /// </summary>
     /// <param name="secret">the secret integer</param>
     /// <returns>a message acknwoldging a secret</returns>
     /// <example>
     /// POST: http://localhost:xx/api/q5/secret
     /// Header:Content-Type: application/json
     /// Body: 5
     /// curl -H"Content-Type: application/json"-d "5" http://localhost:xx/api/q5/secret
     /// POST: http://localhost:xx/api/q5/secret
     /// Header:Content-Type: application/json
     /// Body: -200
     /// curl -H"Content-Type: application/json"-d "-200" http://localhost:xx/api/q5/secret
     /// </example>
        [HttpPost(template: "secret")]
        [Consumes("application/json")]
        public string ScretWord([FromBody] int secret)
        {
            return $"Shh.. the secret is {secret}";
        }
    }
}
