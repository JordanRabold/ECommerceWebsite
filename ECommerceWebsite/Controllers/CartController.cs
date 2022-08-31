using ECommerceWebsite.Data;
using ECommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebsite.Controllers
{
    public class CartController : Controller
    {
        private readonly CameraGearContext _context;

        public CartController(CameraGearContext context)
        {
            _context = context;
        }

        public IActionResult Add(int id)
        {
            CameraGear gearToAdd = _context.cameraGears.Where(c => c.CameraGearId == id).SingleOrDefault();

            if(gearToAdd == null)
            {
                // Gear with that id doesn't exist
                TempData["Message"] = "Sorry, that gear no longer exists";
                return RedirectToAction("Index", "CameraGear");
            }

            // Todo: Add item to a shopping cart cookie
            TempData["Message"] = "Item added to cart";
            return RedirectToAction("Index", "CameraGear");
        }
    }
}
