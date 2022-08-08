using ECommerceWebsite.Data;
using ECommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{ 
    public class CameraGearController : Controller
    {
        private readonly CameraGearContext _context;

        public CameraGearController(CameraGearContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CameraGear camGear)
        {
            if (ModelState.IsValid)
            {
                // Add to DB
                _context.cameraGears.Add(camGear); // prepares insert
                _context.SaveChanges(); // Executes pending insert

                // Show success message on page
                ViewData["Message"] = $"{camGear.Title} was added successfully!";

                return View();
            }

            return View(camGear);
        }
    }
}
