using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SelahSeries.Models.DTOs;
using SelahSeries.Repository;
using SelahSeries.Repository.Interfaces;

namespace SelahSeries.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IPostRepository _postRepo;
        private readonly INotificationRepository _notificationRepo;

        public AdminController(IPostRepository postRepo, INotificationRepository notificationRepository)
        {
            _postRepo = postRepo;
            _notificationRepo = notificationRepository;

        }
        [Route("[controller]")]
        public async Task<IActionResult> Index([FromQuery] int pageIndex = 1)
        {
            var pageParam = new PaginationParam
            {
                PageIndex = pageIndex,
                Limit = 20,
                SortColoumn = "CreatedAt"
            };

            var notifications = await _notificationRepo.GetNotificationsByPage(pageParam);
            ViewBag.NotificationCount = notifications.TotalCount;
            ViewBag.CurrentPage = notifications.Currentpage;
            ViewBag.UnreadNotification = await _notificationRepo.GetUnreadNotificationCount();
            return View(notifications.Source);
        }

        [HttpGet]
        public async Task<IActionResult> Subscribers()
        {
            var subscribers = await _postRepo.GetPostSuscribers();
            return View(subscribers);
        }

        [HttpGet]
        public ActionResult SignOut()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["Alert"] = " Logout successful ";
            return RedirectToAction("Index", "Home");
        }
      
        [HttpPost]
        public async Task<JsonResult> MarkAsRead([FromBody]int notificationId)
        {
            try
            {
                var notification = await _notificationRepo.MarkNotificationAsRead(notificationId);
                return Json(JsonConvert.SerializeObject(notification));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}