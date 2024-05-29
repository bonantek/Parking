using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Parking.Data.Services;
using Parking.Models;

namespace Parking.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IParkingService _parkingService;

    public HomeController(ILogger<HomeController> logger, IParkingService parkingService)
    {
        _logger = logger;
        _parkingService = parkingService;
    }

    public async Task<IActionResult> Index()
    {
        var parkings = await _parkingService.GetAllAsync();
        return View(parkings);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet, ActionName("404")]
    public IActionResult Error404()
    {
        return View();
    }
}