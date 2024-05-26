using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Parking.Data;
using Parking.Data.Services;

namespace Parking.Controllers
{
    public class ParkingController : Controller
    {
        private readonly IParkingService _service;
        public ParkingController(IParkingService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var parkings = await _service.GetAllAsync();
            return View(parkings);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Manage()
        {
            var parkings = await _service.GetAllAsync();
            return View(parkings);
        }
    }
}