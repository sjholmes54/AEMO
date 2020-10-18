using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AEMO_Demo.Models;

namespace AEMO_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        [HttpPost]
        public IActionResult FindSubtextMatches(string text, string subtext)
        {
            StringServices service = new StringServices();
            string returnValue = "";
            foreach (int i in service.ReturnMatchingIndexes(text, subtext))
            {
                returnValue += i + " ,";
            }

            if (!string.IsNullOrEmpty(returnValue))
            {
                returnValue = returnValue.TrimEnd(',');
            }

            return Content(returnValue);
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
