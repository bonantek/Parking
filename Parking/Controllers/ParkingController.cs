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
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Models.Parking parking)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(parking);
                return RedirectToAction("Manage");
            }
            return View(parking);
        }
        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Manage()
        {
            var parkings = await _service.GetAllAsync();
            return View(parkings);
        }
        
        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Manage");
        }
    }
}