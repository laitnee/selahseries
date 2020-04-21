using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SelahSeries.Controllers
{
    public class SupportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Message_Form()
        {
            return View();
        }


        public IActionResult Bio()
        {
            return View();
        }
    }
}