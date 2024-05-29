using Microsoft.AspNetCore.Mvc;

namespace Parking.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}