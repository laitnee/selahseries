using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SelahSeries.Core.Pagination;
using SelahSeries.Models.DTOs;
using SelahSeries.Repository.Interfaces;
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

        public EMIController(IEventRepository eventRepo, ITestimonyRepository testimonyRepo, IGalleryRepository galleryRepo, IMapper mapper)
        {
            this.eventRepo = eventRepo;
            this.testimonyRepo = testimonyRepo;
            this.galleryRepo = galleryRepo;
            this.mapper = mapper;
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

        [Route("/emeraldlight/volunteer")]
        public IActionResult Volunteer()
        {
            return View();
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
