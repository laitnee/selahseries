using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using SelahSeries.Repository;

namespace SelahSeries.Controllers
{
    public class HomeController : Controller
    {
        static List<Post> BlogPosts = new List<Post>
        {
            new Post
            {
                PostId = 1,
                ParentId = 2,
                Author = "Lekan Agunbiade",
                Title = "Why do we cry",
                Content = "We cry not because we are weak but because we are humans We cry not because we are weak but because we are humans We cry not because we are weak but because we are humans We cry not because we are weak but because we are humans We cry not because we are weak but because we are humans We cry not because we are weak but because we are humans We cry not because we are weak but because we are humans We cry not because we are weak but because we are humans",
                TitleImageUrl = "images/me.jpg",
                Published = true,
                CreatedAt = new DateTime(2009, 11, 23),
                ModifiedAt = new DateTime(2019, 05, 09),
                CategoryId = 1,
            },
            new Post
            {
                PostId = 2,
                ParentId = 2,
                Author = "Titilayo Agunbiade",
                Title = "Marriage Life",
                Content = "What would we be if we are single to stupor",
                TitleImageUrl = "images/me.jpg",
                Published = true,
                CreatedAt = new DateTime(2012, 11, 23),
                ModifiedAt = new DateTime(2019, 05, 09),
                CategoryId = 1,
            },
            new Post
            {
                PostId = 3,
                ParentId = 2,
                Author = "Lois Smart",
                Title = "The US president travels to China",
                Content = "It takes training, hardwork, tenacity and little talent to forge a path - Olympiad champion",
                TitleImageUrl = "images/me.jpg",
                Published = false,
                CreatedAt = new DateTime(2013, 11, 23),
                ModifiedAt = new DateTime(2019, 05, 09),
                CategoryId = 1,
            },
            new Post
            {
                PostId = 4,
                ParentId = 2,
                Author = "Lois Smart",
                Title = "The path to fulfillment in life",
                Content = "It takes training, hardwork, tenacity and little talent to forge a path - Olympiad champion",
                TitleImageUrl = "images/me.jpg",
                Published = false,
                CreatedAt = new DateTime(2013, 11, 23),
                ModifiedAt = new DateTime(2019, 05, 09),
                CategoryId = 1,
            },
            new Post
            {
                PostId = 5,
                ParentId = 2,
                Author = "Lois Smart",
                Title = "The path of a champion is easy but seems difficult",
                Content = "It takes training, hardwork, tenacity and little talent to forge a path - Olympiad champion",
                TitleImageUrl = "images/me.jpg",
                Published = false,
                CreatedAt = new DateTime(2013, 11, 23),
                ModifiedAt = new DateTime(2019, 05, 09),
                CategoryId = 1,
            },
            new Post
            {
                PostId = 6,
                ParentId = 2,
                Author = "Lois Smart",
                Title = "Nigeria to elect a new Governor for Lagos state",
                Content = "It takes training, hardwork, tenacity and little talent to forge a path - Olympiad champion",
                TitleImageUrl = "images/me.jpg",
                Published = false,
                CreatedAt = new DateTime(2013, 11, 23),
                ModifiedAt = new DateTime(2019, 05, 09),
                CategoryId = 1,
            },
            new Post
            {
                PostId = 7,
                ParentId = 2,
                Author = "Lois Smart",
                Title = "Obioma misses a goal in Eagles championship",
                Content = "It takes training, hardwork, tenacity and little talent to forge a path - Olympiad champion",
                TitleImageUrl = "images/me.jpg",
                Published = false,
                CreatedAt = new DateTime(2013, 11, 23),
                ModifiedAt = new DateTime(2019, 05, 09),
                CategoryId = 1,
            },
            new Post
            {
                PostId = 8,
                ParentId = 2,
                Author = "Lois Smart",
                Title = "keeping yourself undefiled",
                Content = "It takes training, hardwork, tenacity and little talent to forge a path - Olympiad champion",
                TitleImageUrl = "images/me.jpg",
                Published = false,
                CreatedAt = new DateTime(2013, 11, 23),
                ModifiedAt = new DateTime(2019, 05, 09),
                CategoryId = 1,
            },
            new Post
            {
                PostId = 9,
                ParentId = 2,
                Author = "Lois Smart",
                Title = "Growth: An inevitable part of the human life",
                Content = "It takes training, hardwork, tenacity and little talent to forge a path - Olympiad champion",
                TitleImageUrl = "images/me.jpg",
                Published = false,
                CreatedAt = new DateTime(2013, 11, 23),
                ModifiedAt = new DateTime(2019, 05, 09),
                CategoryId = 1,
            },
            new Post
            {
                PostId = 10,
                ParentId = 2,
                Author = "Lois Smart",
                Title = "How to plan your day to have maximum results",
                Content = "It takes training, hardwork, tenacity and little talent to forge a path - Olympiad champion",
                TitleImageUrl = "images/me.jpg",
                Published = false,
                CreatedAt = new DateTime(2013, 11, 23),
                ModifiedAt = new DateTime(2019, 05, 09),
                CategoryId = 1,
            },
            new Post
            {
                PostId = 11,
                ParentId = 2,
                Author = "Lois Smart",
                Title = "Keeping your life devoted to God",
                Content = "It takes training, hardwork, tenacity and little talent to forge a path - Olympiad champion",
                TitleImageUrl = "images/me.jpg",
                Published = false,
                CreatedAt = new DateTime(2013, 11, 23),
                ModifiedAt = new DateTime(2019, 05, 09),
                CategoryId = 1,
            }

        };
        private IPostRepository _postRepository;
        public HomeController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public IActionResult Index()
        {
            return View(BlogPosts);
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
