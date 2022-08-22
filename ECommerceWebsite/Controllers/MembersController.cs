using ECommerceWebsite.Data;
using ECommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class MembersController : Controller
    {
        private readonly CameraGearContext _context;

        public MembersController(CameraGearContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel regModel)
        {
            if (ModelState.IsValid)
            {
                // Map RegisterViewModel data to Member object
                Member newMember = new()
                {
                    Email = regModel.Email,
                    Password = regModel.Password
                };

                _context.members.Add(newMember); // add to db
                await _context.SaveChangesAsync(); // save changes

                // redirect to homepage
                return RedirectToAction("Index", "Home");
            }
            return View(regModel);
        }
    }
}
