using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RentACars.Data;
using RentACars.Models;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class CarsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CarsController> _logger;

    public CarsController(ApplicationDbContext context, ILogger<CarsController> logger)
    {
        _context = context;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger)); // Null check for logger
    }

    public IActionResult Index()
    {
        var cars = _context.Cars
                           .Where(c => c.BrandId.HasValue && c.ModelId.HasValue && c.CityId.HasValue && c.PricePerDay.HasValue)
                           .ToList();
        return View(cars);
    }
    public IActionResult PostCar()
    {
        var brands = _context.Brands.ToList();
        var cities = _context.Cities.ToList();

        if (brands == null || !brands.Any())
        {
            _logger.LogError("Brands are null or empty");
            return View("Error");
        }

        if (cities == null || !cities.Any())
        {
            _logger.LogError("Cities are null or empty");
            return View("Error");
        }

        ViewBag.Brands = _context.Brands.ToList();
        ViewBag.Models = _context.Models.ToList();
        ViewBag.Cities = _context.Cities.ToList();

        // Initialize a new Car object to bind the form correctly
        var car = new Car();
        return View(car);
    }



    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostCar(Car car, IFormFile image)
    {
        if (ModelState.IsValid)
        {
            if (image != null && image.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await image.CopyToAsync(memoryStream);
                    car.Image = memoryStream.ToArray(); // Записва изображението като байтов масив
                }
            }

            _context.Cars.Add(car);
            _context.SaveChanges();

            return RedirectToAction("Index", "Cars");
        }

        // If the model state is not valid, re-render the form with errors
        ViewBag.Brands = _context.Brands.ToList();
        ViewBag.Models = _context.Models.ToList();
        ViewBag.Cities = _context.Cities.ToList();

        return View(car); // Return the form with the invalid car object
    }





    // Get models based on selected brand
    public JsonResult GetModelsByBrand(int brandId)
    {
        var models = _context.Models
                             .Where(m => m.BrandId == brandId)
                             .ToList();

        return Json(models.Select(m => new { id = m.Id, name = m.Name }));
    }
}
