using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q8Controller : ControllerBase
    {
        private const double SmallPrice = 25.50;
        private const double LargePrice = 45.50;
        private const double HstRate = 0.13;
        /// <summary>
        /// this method calculate total bill including tax
        /// </summary>
        /// <param name="Small">Price of small pushies</param>
        /// <param name="Large">Price of large pushies</param>
        /// <returns>total bill with tax</returns>
        /// <example>
        /// POST: http://localhost:xx/api/q8/squashfellows
        /// Header:Content-Type:application/x-www-form-urlencoded
        /// Body: Small=1&Large=1
        /// curl -H"Content-Type:application/x-www-form-urlencoded" -d"Small=1&Large=1" http://localhost:xx/api/q8/squashfellows
        /// POST: http://localhost:xx/api/q8/squashfellows
        /// Header:Content-Type:application/x-www-form-urlencoded
        /// Body: Small=2&Large=1
        /// curl -H"Content-Type:application/x-www-form-urlencoded" -d"Small=2&Large=1" http://localhost:xx/api/q8/squashfellows
        /// POST: http://localhost:xx/api/q8/squashfellows
        /// Header:Content-Type:application/x-www-form-urlencoded
        /// Body: Small=100&Large=100
        /// curl -H"Content-Type:application/x-www-form-urlencoded" -d"Small=100&Large=100" http://localhost:xx/api/q8/squashfellows
        /// 
        /// </example>
        [HttpPost(template:"squashfellows")]
        public string SquashFellowsCheckout([FromForm] int Small, [FromForm] int Large)
        {

            double smallTotal = Small * SmallPrice;
            double largeTotal = Large * LargePrice;
            double subtotal = smallTotal + largeTotal;


            double tax = Math.Round(subtotal * HstRate, 2);


            double total = subtotal + tax;

            string response = $"{Small} Small @ {SmallPrice.ToString("C3", CultureInfo.CurrentCulture)} = {smallTotal.ToString("C3", CultureInfo.CurrentCulture)}; " +
                              $"{Large} Large @ {LargePrice.ToString("C3", CultureInfo.CurrentCulture)} = {largeTotal.ToString("C3", CultureInfo.CurrentCulture)}; " +
                              $"Subtotal = {subtotal.ToString("C3", CultureInfo.CurrentCulture)}; " +
                              $"Tax = {tax.ToString("C3", CultureInfo.CurrentCulture)} HST; " +
                              $"Total = {total.ToString("C3", CultureInfo.CurrentCulture)}";


            return response;
        }
    }
}
