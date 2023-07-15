using Microsoft.AspNetCore.Mvc;
using PracticalSeventeen.Models;
using System.Diagnostics;

namespace PracticalSeventeen.Controllers
{
    public class ErrorController : Controller
    {
        /// <summary>
        /// Handles errors
        /// </summary>
        /// <returns></returns>
        [Route("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
