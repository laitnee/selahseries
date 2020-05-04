using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SelahSeries.Data;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using SelahSeries.Repository;

namespace SelahSeries.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IPostRepository _postRepo;
        //public HomeController(
        //   //SeedData seedData
        //   )
        //{
        //}
        public HomeController(IPostRepository postRepo, IMapper mapper, IHostingEnvironment environment)
        {
            _postRepo = postRepo;
            _mapper = mapper;
            hostingEnvironment = environment;
        }
        public async  Task<IActionResult> Index()
        {
            var pageParam = new PaginationParam
            {
                PageIndex = 1,
                Limit = 20,
                SortColoumn = "CreatedAt"
            };
            var posts = await _postRepo.GetPublishedPosts(pageParam);
            return View(posts.Source);
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

        public IActionResult Contact()
        {
           

            return View();
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
