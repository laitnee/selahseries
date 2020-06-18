using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SelahSeries.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        [Route("[controller]")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignOut()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["Alert"] = " Logout successful ";
            return RedirectToAction("Index", "Home");
        }
    }
}