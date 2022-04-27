using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PickupTimeExample.Models;
using System.Diagnostics;

namespace PickupTimeExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Get Pickup times from the DB -- will need to pass in the date selection made by the customer
            List<DateTime> UnavailableTimes = new List<DateTime>() { new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0) };
            HomePageModel HomeModel = new HomePageModel(new PickupTimeModel(UnavailableTimes, DateTime.Now));
            return View(HomeModel);
        }

        public IActionResult GenerateDatePicker(DateTime SelectedTime)
        {
            List<DateTime> UnavailableTimes = new List<DateTime>() { new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0) };
            return PartialView("_DatePicker", new PickupTimeModel(UnavailableTimes, SelectedTime));
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