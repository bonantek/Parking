using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking.Data;
using Parking.Data.Services;

namespace Parking.Controllers
{
    public class ParkingController : Controller
    {
        private readonly IParkingService _parkingService;
        private readonly AppDbContext _context;
        public ParkingController(IParkingService service, AppDbContext context)
        {
            _parkingService = service;
            _context = context;
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
        public async Task<IActionResult> Update(System.Guid id)
        {
            var parking = _context.Parkings.Find(id);
            
            _context.Entry(parking).Collection(p => p.ParkingSlots).Load();
            
            return View(parking);
        }
        
        [HttpPost, ActionName("Update"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePost(System.Guid id)
        {
            var parkingToUpdate = await _context.Parkings.FindAsync(id);

            if (await TryUpdateModelAsync<Models.Parking>(parkingToUpdate, "",
                    p => p.Name,
                    p => p.City,
                    p => p.Street,
                    p => p.StreetNr,
                    p => p.Description))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                                                 "Try again, and if the problem persists, " +
                                                 "see your system administrator.");
                }
            }
            
            return RedirectToAction("Manage");
        }
        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _parkingService.DeleteAsync(id);
            return RedirectToAction("Manage");
        }
    }
}