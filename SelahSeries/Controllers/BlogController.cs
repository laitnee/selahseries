using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SelahSeries.Controllers
{
    public class BlogController : Controller
    {
        // GET: /<controller>/
        public IActionResult Category()
        {
            return View();
        }

        public IActionResult Post()
        {
            return View();
        }


    }
}
