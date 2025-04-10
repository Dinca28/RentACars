using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RentACars.Controllers;
using RentACars.Data;
using RentACars.Models;

public class CarsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<HomeController> _logger;

    public CarsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var cars = _context.Cars.ToList();
        return View(cars);
    }

    // GET: Cars/PostCar
    public IActionResult PostCar()
        {
        var carModel = new Car(); // For example, if you're just creating an empty car model for the form
        return View(carModel); // Pass the model to the view
    }
    
    // POST: Cars/PostCar
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostCar(Car car, IFormFile image)
    {
        if (ModelState.IsValid)
        {
            if (image != null && image.Length > 0)
            {
                // Save the image to the "images" folder inside wwwroot
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", image.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
                car.ImageUrl = $"/images/{image.FileName}";  // Store image path in the database
            }

            _context.Add(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); // Redirect to car list page
        }
        return View(car);
    }

    [HttpPost]
    [HttpPost]
    public IActionResult Create(Car car)
    {
        if (!ModelState.IsValid)
        {
            return View(car);
        }

        _context.Cars.Add(car);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }



}
