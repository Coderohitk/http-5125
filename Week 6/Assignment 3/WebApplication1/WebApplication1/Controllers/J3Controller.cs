using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J3Controller : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instructions"></param>
        /// <example></example>
        /// <returns></returns>
        [HttpPost(template:"Special Instrucions")]
        [Consumes("application/x-www-form-urlencoded")]
        public string InstructionFollowed([FromForm]string instructions)
        {
            string[] instructionList = instructions.Split(',');
            string results = "";
            string lastDirection = "";
            foreach(var i in instructionList)
            {
                if(i=="99999")
                { break;
                }
                string direction;
                int first2digits = int.Parse(i.Substring(0, 2));
                int Last3Digits = int.Parse(i.Substring(2, 3));
                int sumOFfirsttwo = (first2digits / 10) + (first2digits % 10);
                if(sumOFfirsttwo==0)
                {
                    direction = lastDirection;
                }
                else if(sumOFfirsttwo%2==0)
                {
                    direction = "right";
                }
                else
                {
                    direction = "left";
                }
                lastDirection = direction;
                results += $"{direction} {Last3Digits}\n";
            }
            return results.TrimEnd('\n');
        }
    }
}
