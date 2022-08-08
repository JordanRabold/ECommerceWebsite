using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class CameraGearController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
