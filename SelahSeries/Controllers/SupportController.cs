using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelahSeries.Services;

namespace SelahSeries.Controllers
{
    public class SupportController : Controller
    {
        private readonly IEmailService _emailService;
        public SupportController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Send_Message()
        {
            return View();
        }

        [HttpPost]
  
        public async Task<ActionResult> Send_Message([FromForm] string fullname, int age, string gender, long phone, string category, string email, string address, string message)
        {

            try
            {
                var subject = category;
                message = "Name: " + fullname + "\n" + "Email Address: " + email + "\n" + "Age: " + age + "\n" + "Gender: " + gender + "\n" +"Location: " + address + "\n" + "Phone Number: " + phone + "\n" + "Message: " + message;
                await _emailService.SendEmail(subject, message);
                ViewBag.Error = "Unable to send message, try again";
                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Unable to send message, try again";
                return View();
            }
        }


        public IActionResult Bio(int id)
        {
            ViewData["Id"] = id;
            return View();
        }
    }
}