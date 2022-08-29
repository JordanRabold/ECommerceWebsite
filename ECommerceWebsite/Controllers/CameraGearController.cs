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
        public async Task<IActionResult> Index(int? id)
        {
            const int NumCameraGearToDisplayPerPage = 3; // how many pieces of gear to display per page
            const int PageOffSet = 1; // Need page offset to use current page and figure out, num gear to display

            int currentPage = id ?? 1; // Set currentPage to id if it has a value, otherwise use 1

            // Get all camera gear from database
            List<CameraGear> camGear = await (from gear in _context.cameraGears
                                              select gear)
                                              .Skip(NumCameraGearToDisplayPerPage * (currentPage - PageOffSet))
                                              .Take(NumCameraGearToDisplayPerPage)
                                              .ToListAsync(); 

            // show on webpage
            return View(camGear);
        }

        // EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            CameraGear gearToEdit = await _context.cameraGears.FindAsync(id); // find gear by id
            if (gearToEdit == null)
            {
                return NotFound();
            }
            return View(gearToEdit);
        }

        // UPDATE
        [HttpPost]
        public async Task<IActionResult> Edit(CameraGear gearModel)
        {
            if (ModelState.IsValid)
            {
                _context.cameraGears.Update(gearModel);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{gearModel.Title} was updated successfully!";
                return RedirectToAction("Index");
            }
             return View(gearModel);
        }

        // DELETE
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            CameraGear? gearToDelete = await _context.cameraGears.FindAsync(id); // find gear by id

            if (gearToDelete == null)
            {
                return NotFound();
            }

            return View(gearToDelete);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            CameraGear gearToDelete = await _context.cameraGears.FindAsync(id); // find gear by id
            if(gearToDelete != null)
            {
                _context.cameraGears.Remove(gearToDelete);
                await _context.SaveChangesAsync();
                TempData["Message"] = gearToDelete.Title + " was deleted successfully";
                return RedirectToAction("Index");
            }

            TempData["Message"] = "This gear was already deleted";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            CameraGear gearDetails = await _context.cameraGears.FindAsync(id);
            if(gearDetails == null)
            {
                return NotFound();
            }

            return View(gearDetails);
        }
    }
}
