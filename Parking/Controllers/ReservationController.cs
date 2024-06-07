using System.Dynamic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking.Data;
using Parking.Data.Services;
using Parking.Models;

namespace Parking.Controllers
{
    public class ReservationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICarService _carService;
        private readonly IReservationService _reservationService;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public ReservationController(AppDbContext context,
            ICarService carService,
            IReservationService reservationService,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _carService = carService;
            _reservationService = reservationService;
            _userManager = userManager;
        }

        public async Task<IActionResult> IndexList(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var reservations = await _reservationService.GetAllForUser(user);
            return View("UserReservations", reservations);
        }
        
        [Authorize]
        public async Task<IActionResult> Create(System.Guid id)
        {
            if (await _context.Parkings
                    .Include(p => p.ParkingSlots)
                    .ThenInclude(ps => ps.Reservations)
                    .SingleOrDefaultAsync(p => p.Id == id) is not {} parking)
            {
                return Redirect("/Home/404");
            }
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
            var parking = await _context.Parkings
                .Include(p => p.ParkingSlots)
                .ThenInclude(ps => ps.Reservations)
                .SingleAsync(p => p.Id == id);
            if (parking == null)
            {
                return Redirect("/Home/404");
            }
            
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
                reservation = await _reservationService.CreateReservation(reservation);
                TempData["SuccessMessage"] = "Successfully created a reservation.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error while creating a reservation: {ex.Message}";
            }
            return View(reservation);
        }

        [Authorize]
        public async Task<IActionResult> UserReservations()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return NotFound();
            }

            var reservations = await _reservationService.GetAllForUser(user);
            return View(reservations);
        }
        [Authorize, HttpPost]
        public async Task<IActionResult> Deactivate(Guid id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return NotFound();
            }

            try
            {
                await _context.Entry(user).Collection(p => p.Reservations).LoadAsync();
                var reservation = user.Reservations.Single(r => r.Id == id);
            
                if (reservation == null) return Redirect("/Home/404");
                reservation.IsActive = false;
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Successfully deactivated a reservation";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error while deactivating a reservation: {ex.Message}";
            }


            return RedirectToAction("UserReservations");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ParkingSlotReservations(Guid id)
        {
            var parkingSlot = await _context.ParkingSlots.FindAsync(id);
            if (parkingSlot == null)
            {
                return Redirect("/Home/404");
            }

            var reservations = await _reservationService.GetAllForParkingSlot(parkingSlot);
            return View(reservations);
        }
        [Authorize(Roles = "Admin"), HttpPost]
        public async Task<IActionResult> DeactivateAdmin(Guid id)
        {
            var parkingSlotId = new Guid();
            try
            {
                var reservation = await _context.Reservations
                    .Include(r => r.ParkingSlot)
                    .SingleAsync(r => r.Id == id);
            
                if (reservation == null) return Redirect("/Home/404");
                reservation.IsActive = false;
                parkingSlotId = reservation.ParkingSlot.Id;
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Successfully deactivated a reservation";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error while deactivating a reservation: {ex.Message}";
            }
            
            return RedirectToAction("ParkingSlotReservations", new {id = parkingSlotId.ToString()});
        }
    }
}