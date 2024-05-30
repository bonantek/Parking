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
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return NotFound();
            }
            var cars = await _carService.GetAllByUserAsync(user.Id);
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
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                car.User = user;
                car.UserId = user.Id;
                
                ModelState.Clear();
                
                if (TryValidateModel(car))
                {
                    try
                    {
                        await _carService.AddAsync(car);
                        TempData["SuccessMessage"] = "Successfully added new car.";
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        TempData["ErrorMessage"] = $"Error while adding a new car: {ex.Message}";
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Model state is not valid. Please check your inputs.";
                    return View(car);
                }
            }
            else
            {
                return NotFound();
            }

            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                try
                {
                    await _carService.DeleteAsync(id);
                    TempData["SuccessMessage"] = "Successfully deleted your car.";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Some error occured while deleteing your car";
                }
            }

            return NotFound();
        }
    }
}