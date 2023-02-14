using Microsoft.AspNetCore.Mvc;
using Web.Helper;

namespace Web.Controllers
{
    [LoginFilter]
    public class UserController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
    }
}
