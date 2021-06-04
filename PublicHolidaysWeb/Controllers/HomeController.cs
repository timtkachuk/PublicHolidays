using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PublicHolidaysWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PublicHolidaysWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            await PrepareCountriesList();
            ViewData["query"] = new HolidayQueryViewModel();
            return View(Enumerable.Empty<Holiday>());
        }

        [HttpPost]
        public async Task<IActionResult> Index(HolidayQueryViewModel model)
        {

            await PrepareCountriesList();
            var client = new HttpClient();
            var result = await client.GetStringAsync($"https://kayaposoft.com/enrico/json/v2.0?action=getHolidaysForYear&year={model.Year}&country={model.CountryCode}&holidayType=public_holiday");
            var holidays = JsonConvert.DeserializeObject<IEnumerable<Holiday>>(result);
            ViewData["query"] = model;
            return View(holidays);
        }

        private async Task PrepareCountriesList()
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync("https://kayaposoft.com/enrico/json/v2.0?action=getSupportedCountries");
            ViewData["countries"] = JsonConvert.DeserializeObject<IEnumerable<Country>>(result);
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
