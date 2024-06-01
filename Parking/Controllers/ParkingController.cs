using System.Runtime.InteropServices.JavaScript;
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
                TempData["SuccessMessage"] = "Successfully created the parking.";
                return RedirectToAction("Manage");
            }
            TempData["ErrorMessage"] = $"Couldn't create parking";
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
            var parking = await _context.Parkings.FindAsync(id);
            
            await _context.Entry(parking).Collection(p => p.ParkingSlots).LoadAsync();
            
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
                    TempData["SuccessMessage"] = "Successfully updated the parking.";
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error while adding a new car: {ex.Message}";
                }
            }
            
            return RedirectToAction("Manage");
        }
        
        [Authorize(Roles = "Admin"), HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _parkingService.DeleteAsync(id);
            TempData["SuccessMessage"] = "Successfully deleted the parking.";
            return RedirectToAction("Manage");
        }

        public class ParkingSlotAvailabilityDto
        {
            public DateTime startDate { get; set; }
            public DateTime endDate { get; set; }
            
        }

        [HttpPost, Authorize]
        public async Task<JsonResult> ParkingSlotsAvailability(Guid id, [FromBody] ParkingSlotAvailabilityDto test)
        {
            var parking = await _parkingService.GetByIdWithSlotsAndReservations(id);
            var availability = new Dictionary<string, bool>();
            foreach (var parkingSlot in parking.ParkingSlots)
            {
                availability.Add(parkingSlot.Id.ToString(), parkingSlot.IsAvailable(test.startDate.ToUniversalTime(), test.endDate.ToUniversalTime()));
            }
            return Json(availability);
        }
    }
}