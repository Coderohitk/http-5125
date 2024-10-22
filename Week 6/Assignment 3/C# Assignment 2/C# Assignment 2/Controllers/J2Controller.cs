using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C__Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Controller : ControllerBase
    {
        /// <summary>
        /// Cakculates the total spiceness according to spices added
        /// </summary>
        /// <param name="ingridents">Contains all the spicesSpices names</param>
        /// <returns>returns the total spicness calculating with there corresponding SHU value</returns>
        /// <example>
        /// GET api/J2/ChiliPepper=Poblano,Cayenne,Thai,Poblano->
        /// 118000
        /// GET api/J2/ChiliPepper=Habanero,Habanero,Habanero,Habanero,Habanero->
        /// 625000
        /// GET api/J2/ChiliPepper=Poblano,Mirasol,Serrano,Cayenne,Thai,Habanero,Serrano->
        /// 278500
        /// </example>
        [HttpGet(template: "ChiliPepper={ingridents}")]
        public int TotalSpicines(string ingridents)
        {
            Dictionary<string, int> peppers = new()
            {
               { "Poblano",1500 },
               { "Mirasol",6000 },
               { "Serrano",15500 },
               { "Cayenne",40000 },
               { "Thai",75000 },
               { "Habanero",125000 }
            };
            string[] pepperslist = ingridents.Split(',');
            int total = 0;
            foreach (var pepper in pepperslist)
            {
                if (peppers.ContainsKey(pepper))
                {
                    total += peppers[pepper];
                }
            }
            return total;
        }
        /// <summary>
        /// 2020 J2 determine the first day when infected people quantity exceeded the threshold
        /// </summary>
        /// <param name="P">the threshold for infected people</param>
        /// <param name="N">The initial number of infected people</param>
        /// <param name="R">the rate of new infected people caused by already infected people</param>
        /// <returns>The first day on which the total number of infected individuals exceeds P.</returns>
        /// <example>
        /// POST: api/J1/Epidemiology
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// Post data: P=750&N=1&R=5
        /// ->4
        /// POST: api/J1/Epidemiology
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// Post data: P=10&N=2&R=1
        /// ->5
        /// </example>
        [HttpPost(template: "Epidemiology")]
        [Consumes("application/x-www-form-urlencoded")]
        public int Firstdays([FromForm]int P,[FromForm] int N,[FromForm] int R)
        {
            int totalInfected = N; 
            int dailyInfected = N; 
            int day = 0; 
            while (totalInfected <= P)
            {
                day++; 
                dailyInfected *= R; 
                totalInfected += dailyInfected; 
            }
            return day;
        }
    }
}

