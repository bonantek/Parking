using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting.Hosting;
using Parking.Data;
using Parking.Data.Services;
using Parking.Models;

namespace Parking.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;

        public CarController(ICarService carService, UserManager<ApplicationUser> userManager, AppDbContext context)
        {
            _carService = carService;
            _userManager = userManager;
            _context = context;
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
        
        public async Task<IActionResult> IndexList(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var cars = await _carService.GetAllByUserAsync(user.Id);
            return View("Index", cars);
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

        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carService.GetByIdAsync(id);
            if (car != null)
            {
                return View(car);
            }

            return NotFound();
        }

        [HttpPost, ActionName("Update")]
        
        public async Task<IActionResult> UpdatePost(Car car)
        {
            ModelState.Remove("UserId");
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Invalid input";
                return View(car);
            }

            var carToUpdate = await _carService.GetByIdAsync(car.Id);
            if (await TryUpdateModelAsync<Car>(carToUpdate, "",
                    c => c.Model,
                    c => c.Make,
                    c => c.RegistrationNumber))
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
            return RedirectToAction("Index");

        }
    }

}