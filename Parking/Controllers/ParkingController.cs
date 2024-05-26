using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Parking.Data;
using Parking.Data.Services;

namespace Parking.Controllers
{
    public class ParkingController : Controller
    {
        private readonly IParkingService _parkingService;
        public ParkingController(IParkingService service)
        {
            _parkingService = service;
        }

        public async Task<IActionResult> Index()
        {
            var parkings = await _parkingService.GetAllAsync();
            return View(parkings);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Models.Parking parking)
        {
            if (ModelState.IsValid)
            {
                await _parkingService.AddAsync(parking);
                return RedirectToAction("Manage");
            }
            return View(parking);
        }
        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Manage()
        {
            var parkings = await _parkingService.GetAllAsync();
            return View(parkings);
        }
        
        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _parkingService.DeleteAsync(id);
            return RedirectToAction("Manage");
        }
    }
}