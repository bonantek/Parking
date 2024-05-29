using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting.Hosting;
using Parking.Data.Services;
using Parking.Models;

namespace Parking.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly UserManager<ApplicationUser> _userManager;
        public CarController(ICarService carService, UserManager<ApplicationUser> userManager)
        {
            _carService = carService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var cars = await _carService.GetAllAsync();
            return View(cars);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("RegistrationNumber", "Make", "Model")] Car car)
        {
            var user = await _userManager.GetUserAsync(User);
            car.User = user;
            car.UserId = user.Id;
            
            if (ModelState.IsValid)
            {
                await _carService.AddAsync(car);
                TempData["SuccessMessage"] = "Successfully added new car.";
                return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] = "Error while adding a new car.";
            return View(car);
        }
    }
}