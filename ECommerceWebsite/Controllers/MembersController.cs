using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class MembersController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
