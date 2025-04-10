using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACars.Data;
using RentACars.Models;

namespace RentACars.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Search(string pickupLocation, DateTime pickupDate, DateTime returnDate)
        {
            // Dummy search example
            if (string.IsNullOrWhiteSpace(pickupLocation))
            {
                TempData["NoResults"] = "No cars found for this location.";
                return RedirectToAction("Index");
            }

            // Else redirect to Search Results page
            return RedirectToAction("Results"); // Create this view later
        }


        public JsonResult GetLocations(string term)
        {
            var locations = new List<string>
            {
                "Sofia", "Plovdiv", "Varna", "Burgas", "Dobrich"
            };

            if (string.IsNullOrWhiteSpace(term))
            {
                return Json(locations);
            }

            var results = locations
                .Where(x => x.ToLower().Contains(term.ToLower()))
                .ToList();

            return Json(results);
        }
        public IActionResult Index()
        {
            var cars = _context.Cars
                               .Select(c => new
                               {
                                   c.Id,
                                   c.BrandId,
                                   c.ModelId,
                                   c.CityId,
                                   c.PricePerDay
                               })
                               .ToList();

            // Filter cars with no NULL values in critical fields and log potential problems
            var validCars = cars
                            .Where(c => c.BrandId.HasValue && c.ModelId.HasValue && c.CityId.HasValue && c.PricePerDay.HasValue)
                            .ToList();

            if (validCars == null || !validCars.Any())
            {
                TempData["NoResults"] = "No cars available for the selected filters.";
            }

            // Map back to the Cars model if needed for further use in views
            var finalCars = validCars.Select(c => new Car
            {
                Id = c.Id,
                BrandId = c.BrandId.Value,
                ModelId = c.ModelId.Value,
                CityId = c.CityId.Value,
                PricePerDay = c.PricePerDay.Value
            }).ToList();

            return View(finalCars);
        }




        public IActionResult Details()
        {
            var cars = _context.Cars
                .Select(c => new
                {
                    c.Id,
                    c.BrandId,
                    c.ModelId,
                    c.CityId,
                    c.PricePerDay
                })
                .ToList();

            return View(cars);
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
