using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACars.Data;

namespace RentACars.Controllers
{
    public class AllCarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public AllCarsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var cars = _context.Cars.ToList(); // Get all cars from the database
            return View(cars); // Pass the list of cars to the view
        }
    }
}
