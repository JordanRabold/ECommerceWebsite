using ECommerceWebsite.Data;
using ECommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ECommerceWebsite.Controllers
{
    public class CartController : Controller
    {
        private readonly CameraGearContext _context;
        private const string Cart = "ShoppingCartCookie";

        public CartController(CameraGearContext context)
        {
            _context = context;
        }

        public IActionResult Add(int id)
        {
            CameraGear? gearToAdd = _context.cameraGears.Where(c => c.CameraGearId == id).SingleOrDefault();

            if (gearToAdd == null)
            {
                // Gear with that id doesn't exist
                TempData["Message"] = "Sorry, that gear no longer exists";
                return RedirectToAction("Index", "CameraGear");
            }

            CartGearViewModel cartGear = new()
            {
                CartGearId = gearToAdd.CameraGearId,
                Title = gearToAdd.Title,
                Price = gearToAdd.Price
            };

            List<CartGearViewModel> cartGears = GetExistingCartData();
            cartGears.Add(cartGear);
            WriteShoppingCartCookie(cartGears);

            TempData["Message"] = "Item added to cart";
            return RedirectToAction("Index", "CameraGear");
        }

        private void WriteShoppingCartCookie(List<CartGearViewModel> cartGears)
        {
            string cookieData = JsonConvert.SerializeObject(cartGears);

            HttpContext.Response.Cookies.Append(Cart, cookieData, new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddYears(1)
            });
        }

        /// <summary>
        /// Return the current list of camer gears in the users
        /// shopping cart cookie, if there is no cookie, 
        /// an empty list will be returned
        /// </summary>
        /// <returns></returns>
        private List<CartGearViewModel> GetExistingCartData()
        {
            string? cookie = HttpContext.Request.Cookies[Cart];
            if (string.IsNullOrWhiteSpace(cookie))
            {
                return new List<CartGearViewModel>();
            }

            return JsonConvert.DeserializeObject<List<CartGearViewModel>>(cookie);
        }

        public IActionResult Summary()
        {
            // Read shopping cart data and convert to list of view model
            List<CartGearViewModel> cartGears = GetExistingCartData();
            return View(cartGears);
        }

        public IActionResult Remove(int id)
        {
            List<CartGearViewModel> cartGears = GetExistingCartData();
            CartGearViewModel? targetGear = cartGears.FirstOrDefault(c => c.CartGearId == id);
            cartGears.Remove(targetGear);

            WriteShoppingCartCookie(cartGears);

            return RedirectToAction(nameof(Summary));
        }
    }
}
