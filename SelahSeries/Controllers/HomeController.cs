using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SelahSeries.Core.Pagination;
using SelahSeries.Data;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using SelahSeries.Repository;
using SelahSeries.Services;
using SelahSeries.ViewModels;

namespace SelahSeries.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IPostRepository _postRepo;
        private readonly IConfiguration _configuration;

        public HomeController(IPostRepository postRepo, IMapper mapper, IHostingEnvironment environment, IEmailService emailService, IConfiguration configuration)
        {
            _postRepo = postRepo;
            _mapper = mapper;
            _emailService = emailService;
            _configuration = configuration;

            hostingEnvironment = environment;
        }
        
        [Route("Home/Index")]
        [HttpGet("{pageIndex}")]
        [Route("/")]
        public async Task<IActionResult> Index(int pageIndex, string category)
        {
           PostHomeViewModel postHomeVM = new PostHomeViewModel();
           int page = (pageIndex == 0)? 1 : pageIndex;
           var pageParam = new PaginationParam
            {
                PageIndex = page,
                Limit = 20,
                SortColoumn = "CreatedAt"
            };
            var dontMiss =_postRepo.GetPublishedDMPosts();
            var dontMissVM = _mapper.Map<List<PostListViewModel>>(dontMiss);
            postHomeVM.DontMiss = dontMissVM;

            PaginatedList<Post> latestArticles;
            if (category == "all" || category == null )
            {
                latestArticles = await _postRepo.GetPublishedPosts(pageParam);          
            }
            else {
                latestArticles = await _postRepo.GetPublishedPostsByCategory(pageParam, category);
            }
            postHomeVM.TotalPostCount = latestArticles.TotalCount;
            var latestArticlesVM = _mapper.Map<List<PostListViewModel>>(latestArticles.Source);
            postHomeVM.LatestArticle = latestArticlesVM;

            ViewData["Category"] = category;
            return View(postHomeVM);
        }

        public List<PostListViewModel> Map(PaginatedList<Post> section)
        {
            return _mapper.Map<List<PostListViewModel>>(section);
            
        }

      

        public IActionResult About()
        {
           

            return View();
        }

        [Route("Home/About/Read_More")]
        public IActionResult Read_More()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            if (TempData.ContainsKey("Alert"))
            {
                ViewBag.Alert = TempData["Alert"].ToString();
            }
            if (TempData.ContainsKey("Error"))
            {
                ViewBag.Error = TempData["Error"].ToString();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] AppUser appUser)
        {
            
            if (!string.IsNullOrEmpty(appUser.Username) && string.IsNullOrEmpty(appUser.Password))
            {
                TempData["Error"] = " username or password cannot be blank";
                return RedirectToAction("Login");
            }

            if(PasswordMatch(appUser))
            {
                var claims = new List<Claim>
                {
                  new Claim(ClaimTypes.Name, Guid.NewGuid().ToString())
                };

                var claimsIdentity = new ClaimsIdentity(
                  claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties() { ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)  };

                await HttpContext.SignInAsync(
                  CookieAuthenticationDefaults.AuthenticationScheme,
                  new ClaimsPrincipal(claimsIdentity),
                  authProperties);

                return RedirectToAction("Index", "BlogMgt");
            }

            ViewBag.Error = "Incorrect username or password";
            return View();
            
        }

        private bool PasswordMatch(AppUser appUser)
        {
            var logindetails = _configuration.GetSection("AppUser").Get<AppUser>();
            var passwordSalt = "F1F38C00D0CA2CB04938CA72536611B9BD1067EE343BE83C0AC48BA80204F61EB2C78D99943855915329EB6CD19AA57B812F729C18709C5433725C1D794586A442DC0C4E7C7DE62FA12C173BBDE2584186C471F95BC74F8B1F45C9872BE7F441067D8B734C7F4B97645B7A1C335AD4183C0A0F1A31A88A2E404475DFC51E35CA";
            var usernameSalt = "A5AF4933888FDCD6C2F209CA17D04F214E2D7936462DB2E66FCC8CDB5EA6F85AEB90807BB8F5E97DCE28C2633BC161AAFC0E1CEFFDE9DF2F25346DDCCA474D704D59501E1C46A48C97C5C1A4DD929543C2765ECAF46599B203CA618D5D1D6E0E5B275CBD7878E89156C0799A1A13381ABB9BDFE60DC05D5A99CA1F43191941F5";
            var usernameHash = "";
            var passwordHash = "";

            using (var hmac = new System.Security.Cryptography.HMACSHA512(System.Text.Encoding.UTF8.GetBytes(passwordSalt)))
            {
                passwordHash = BitConverter.ToString(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(appUser.Password))).Replace("-", "");
            }
            using (var hmac = new System.Security.Cryptography.HMACSHA512(System.Text.Encoding.UTF8.GetBytes(usernameSalt)))
            {
                usernameHash = BitConverter.ToString(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(appUser.Username))).Replace("-", "");
            }

            return usernameHash == logindetails.Username && passwordHash == logindetails.Password;
        }

        [HttpGet]
        public IActionResult Contact()
        {
           
            return View();
        }

       

        [HttpPost]
        [Route("home/contact")]
        public async Task<ActionResult> Contact([FromForm] string name, string email, string subject, string message)
        {
           
            try
            {
                message = "Name: " + name + "\n" + "Email Address: " + email + "\n" + "Message: " + message;
                await _emailService.SendEmail(subject, message);
                ViewBag.Alert = "Message was sent successfully";
                return View();
            }
            catch(Exception) {
                ViewBag.Error = "Unable to send message, try again";
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
