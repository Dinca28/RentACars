using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACars.Data;

namespace RentACars.Controllers
{
    public class AllCarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllCarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await _context.Cars
                .Include(c => c.City)
                .ToListAsync();

            return View(cars);
        }
    }
}
