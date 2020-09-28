using Microsoft.AspNetCore.Mvc;
using SelahSeries.Models.DTOs;
using SelahSeries.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Controllers
{
    public class TestimonyController : Controller
    {
        private readonly ITestimonyRepository testimonyRepo;

        public TestimonyController(ITestimonyRepository testimonyRepo)
        {
            this.testimonyRepo = testimonyRepo;
        }

        [Route("~/testimonial")]
        [Route("~/testimonial/index")]
        public async Task<ActionResult> Index()
        {
            var events = testimonyRepo.GetTestimonies();
            return View(events);
        }
    }
}
