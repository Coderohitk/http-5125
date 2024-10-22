using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C__Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J3Controller : ControllerBase
    {
        /// <summary>
        /// 2021 J3 problem in which decodes secret instructions and returns the direction and number of steps based on input
        /// </summary>
        /// <param name="instructions">A list of strings,each contaning 5 digit strings </param>
        /// <example>
        /// POST: api/J3/SecretInstructions
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// Post data: instructions=57234,00907,34100,99999
        /// ->right 234
        /// ->right 907
        /// ->left 100
        /// </example>
        ///  /// <returns>A string contaning all decoded instruction</returns>
        [HttpPost(template: "SpecialInstrucions")]
        [Consumes("application/x-www-form-urlencoded")]
        public string InstructionFollowed([FromForm] string instructions)
        {
            string[] instructionList = instructions.Split(',');
            string results = "";
            string lastDirection = "";
            foreach (var i in instructionList)
            {
                if (i == "99999")
                {
                    break;
                }
                string direction;
                int first2digits = int.Parse(i.Substring(0, 2));
                int Last3Digits = int.Parse(i.Substring(2, 3));
                int sumOFfirsttwo = (first2digits / 10) + (first2digits % 10);
                if (sumOFfirsttwo == 0)
                {
                    direction = lastDirection;
                }
                else if (sumOFfirsttwo % 2 == 0)
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

