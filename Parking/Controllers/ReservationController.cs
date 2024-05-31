using System.Dynamic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly ICarService _carService;
        private readonly IReservationService _reservationService;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public ReservationController(AppDbContext context,
            IParkingService parkingService,
            ICarService carService,
            IReservationService reservationService,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _parkingService = parkingService;
            _carService = carService;
            _reservationService = reservationService;
            _userManager = userManager;
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

            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return NotFound();
            }

            ViewData["UserCars"] = await _carService.GetAllByUserAsync(user.Id);
            return View();
        }
        
        [Authorize, HttpPost, ActionName("Create")]
        public async Task<IActionResult> CreatePost(System.Guid id,
            [Bind("StartDate", "EndDate", "CarId", "ParkingSlotId")] Reservation reservation)
        {
            var parking = await _parkingService.GetByIdAsync(id);
            if (parking == null)
            {
                return Redirect("/Home/404");
            }
            
            await _context.Entry(parking).Collection(p => p.ParkingSlots).LoadAsync();
            ViewData["Parking"] = parking;
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["UserCars"] = await _carService.GetAllByUserAsync(user.Id);
            
            reservation.User = user;
            reservation.UserId = user.Id;
            try
            {
                await _reservationService.CreateReservation(reservation);
                TempData["SuccessMessage"] = "Successfully created a reservation.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error while creating a reservation: {ex.Message}";
            }
            return View();
        }
    }
}