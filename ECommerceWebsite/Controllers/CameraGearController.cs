using ECommerceWebsite.Data;
using ECommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebsite.Controllers
{ 
    public class CameraGearController : Controller
    {
        private readonly CameraGearContext _context;

        public CameraGearController(CameraGearContext context)
        {
            _context = context;
        }

        // CREATE
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CameraGear camGear)
        {
            if (ModelState.IsValid)
            {
                // Add to DB
                _context.cameraGears.Add(camGear); // prepares insert
                await _context.SaveChangesAsync(); // Executes pending insert

                // Show success message on page
                ViewData["Message"] = $"{camGear.Title} was added successfully!";
                return View();
            }

            return View(camGear);
        }

        // RETRIEVE
        public async Task<IActionResult> Index()
        {
            // Get all camera gear from database
            List<CameraGear> camGear = await _context.cameraGears.ToListAsync();

            // show on webpage

            return View(camGear);
        }

        // UPDATE
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            CameraGear gearToEdit = await _context.cameraGears.FindAsync(id);
            if(gearToEdit == null)
            {
                return NotFound();
            }
            return View(gearToEdit);
        }

        // DELETE
        [HttpPost]
        public async Task<IActionResult> Edit(CameraGear gearModel)
        {
            if (ModelState.IsValid)
            {
                _context.cameraGears.Update(gearModel);
                await _context.SaveChangesAsync();
                
                return RedirectToAction("Index");
            }
             return View(gearModel);
            
        }
    }
}
