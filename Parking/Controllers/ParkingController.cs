using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        
        [Authorize(Roles = "Admin")]
        public IActionResult Manage()
        {
            var parkings = _context.Parkings.ToList();
            return View(parkings);
        }
    }
}