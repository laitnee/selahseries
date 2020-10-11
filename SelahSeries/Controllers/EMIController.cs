using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SelahSeries.Core.Pagination;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using SelahSeries.Repository.Interfaces;
using SelahSeries.Services;
using SelahSeries.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Controllers
{
    [AllowAnonymous]
    public class EMIController : Controller
    {
        private readonly IEventRepository eventRepo;
        private readonly ITestimonyRepository testimonyRepo;
        private readonly IGalleryRepository galleryRepo;
        private readonly IMapper mapper;
        private readonly IEmailService emailService;
        private readonly IVolunteerRepository volRepo;

        public EMIController(IEventRepository eventRepo, ITestimonyRepository testimonyRepo, IGalleryRepository galleryRepo, IMapper mapper, IEmailService emailService, IVolunteerRepository volRepo)
        {
            this.eventRepo = eventRepo;
            this.testimonyRepo = testimonyRepo;
            this.galleryRepo = galleryRepo;
            this.mapper = mapper;
            this.emailService = emailService;
            this.volRepo = volRepo;
        }

        [Route("/emeraldlight")]
        [Route("/emeraldlight/index")]
        public IActionResult Index()
        {
            EMIHomeViewModel emiHomeVM = new EMIHomeViewModel();
            var pageParam = new PaginationParam
            {
                PageIndex = 1,
                Limit = 6,
                SortColoumn = "CreatedAt"
            };
            var events = eventRepo.GetEvents();
            var eventsVM = mapper.Map<List<EventListViewModel>>(events);
            emiHomeVM.Events = eventsVM;

            var testimonies = testimonyRepo.GetTestimonies();
            var testimoniesVM = mapper.Map<List<TestimonyListViewModel>>(testimonies);
            emiHomeVM.Testimonies = testimoniesVM;
            
            return View(emiHomeVM);
        }

        [Route("/emeraldlight/about")]
        public IActionResult About()
        {
            var testimonies = testimonyRepo.GetTestimonies();
            return View(testimonies);
        }

        [Route("/emeraldlight/about/readmore")]
        public IActionResult ReadMore()
        {
            return View();
        }

        [HttpGet]
        [Route("/emeraldlight/volunteer")]
        public IActionResult Volunteer()
        {
            return View();
        }

        [HttpPost]
        [Route("/emeraldlight/volunteer")]
        public async Task<IActionResult> Volunteer([FromForm] string fullname, string age, long phone, string email, string address, string message)
        {
            try
            {
                var subject = "Volunteer for Emerald Light Initiative";
                var messageToSelah = "You have a new volunteer for Emerald Light Initiative. \n   Name: " + fullname + "\n" + "   Email Address: " + email + "\n" + "   Age: " + age + "\n" + "   Location: " + address + "\n" + "   Phone Number: " + phone + "\n" + "   Reason for Joining: " + message;
                var messageToVolunteer = "Dear " + fullname + ", \n" + "Your application to join Emerald Light Initiative has been received successfully. We are glad to have you join us as we help women out there. Further details would be communicated to you shortly. \nBest Regards.";
                await emailService.SendEmail(subject, messageToSelah);
                await emailService.SendEmailTo(subject, messageToVolunteer, email);

                var volunteer = new Volunteer()
                {
                    FullName = fullname,
                    Address = address,
                    PhoneNumber = phone,
                    Email = email,
                    CreatedAt = DateTime.Now
                };

                await volRepo.AddVolunteer(volunteer);

                ViewBag.Alert = "Application submitted successfully";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Unable to submit application, try again";
                return View();
            }
        }

        [HttpGet]
        [Route("/emeraldlight/contact-us")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [Route("/emeraldlight/contact-us")]
        public async  Task<IActionResult> Contact([FromForm] string fullname, string age, long phone, string email, string address, string message, string subject)
        {
            try
            {
                message = "Name: " + fullname + "\n" + "Email Address: " + email + "\n" + "Age: " + age + "\n" + "Location: " + address + "\n" + "Phone Number: " + phone + "\n" + "Subject: " + subject + "\n" + "Message: " + message;
                await emailService.SendEmail(subject, message);
                ViewBag.Alert = "Message was sent successfully";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Unable to send message, try again";
                return View();
            }
        }

        [Route("emeraldlight/events")]
        public ActionResult Events()
        {
            var events = eventRepo.GetEvents();
            return View(events);
        }

        [Route("/emeraldlight/event/{eventId}")]
        public async Task<IActionResult> Event(int eventId)
        {
            try
            {
                var e_event = await eventRepo.GetEvent(eventId);
                return View(e_event);
            }
            catch
            {
                return View();
            }
        }

        [Route("/emeraldlight/gallery")]
        public IActionResult Gallery()
        {
            var pictures = galleryRepo.GetPictures();
            return View(pictures);
        }

        [Route("/testimonials")]
        public ActionResult Testimonials()
        {
            var testimonies = testimonyRepo.GetTestimonies();
            return View(testimonies);
        }
    }
}
