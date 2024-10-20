using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C__Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Controller : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingridents"></param>
        /// <returns></returns>
        [HttpGet(template: "ChiliPeppers&Ingredients={ingridents}")]
        public int TotalSpicines(string ingridents)
        {
            Dictionary<string, int> peppers = new Dictionary<string, int>
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
        /// 
        /// </summary>
        /// <param name="P"></param>
        /// <param name="N"></param>
        /// <param name="R"></param>
        /// <returns></returns>
        [HttpGet(template: "Epidemiology")]
        public int Tdays(int P, int N, int R)
        {
            int totalInfected = N;
            int dailyInfected = N;
            for (int day = 1; totalInfected <= P; day++)
            {
                dailyInfected *= R;
                totalInfected += dailyInfected;

                if (totalInfected > P)
                {
                    return day;
                }
            }

            return -1;
        }
    }
}

