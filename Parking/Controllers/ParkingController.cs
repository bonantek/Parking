using Microsoft.AspNetCore.Mvc;
using Parking.Data;

namespace Parking.Controllers
{
    public class ParkingController : Controller
    {
        private readonly AppDbContext _context;
        public ParkingController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IActionResult Index()
        {
            var parkings = _context.Parkings.ToList();
            return View(parkings);
        }
    }
}