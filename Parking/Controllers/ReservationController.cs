using System.Dynamic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Parking.Data;
using Parking.Data.Services;
using Parking.Models;

namespace Parking.Controllers
{
    public class ReservationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IParkingService _parkingService;
        public ReservationController(AppDbContext context, IParkingService parkingService)
        {
            _context = context;
            _parkingService = parkingService;
        }

        [Authorize]
        public async Task<IActionResult> Create(System.Guid id)
        {
            var parking = await _parkingService.GetByIdAsync(id);
            if (parking == null)
            {
                return Redirect("/Home/404");
            }
            await _context.Entry(parking).Collection(p => p.ParkingSlots).LoadAsync();
            ViewData["Parking"] = parking;
            return View();
        }
        [Authorize, HttpPost, ActionName("Create")]
        public async Task<IActionResult> CreatePost(System.Guid id,
            [Bind("DateStart", "DateEnd")] Reservation reservation)
        {
            var parking = await _parkingService.GetByIdAsync(id);
            if (parking == null)
            {
                return Redirect("/Home/404");
            }
            await _context.Entry(parking).Collection(p => p.ParkingSlots).LoadAsync();
            ViewData["Parking"] = parking;
            return View();
        }
       
    }
}