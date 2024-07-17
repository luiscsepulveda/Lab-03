using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReadDB.Data.DataAccess; // Ensure this is the correct namespace for your DataAccess
using ReadDB.Models; // Ensure this is the correct namespace for your models
using lab10.Models; // Ensure this is the correct namespace for ErrorViewModel

namespace lab10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataAccess _dataAccess;

        public HomeController(ILogger<HomeController> logger, DataAccess dataAccess)
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }

        public IActionResult Index()
        {
            List<YourModel> data = _dataAccess.GetData();
            return View(data);
        }

        public IActionResult Privacy()
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
