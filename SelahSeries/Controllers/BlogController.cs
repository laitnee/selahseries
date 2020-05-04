using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SelahSeries.Models.DTOs;
using SelahSeries.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SelahSeries.Controllers
{
    
    public class BlogController : Controller
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IPostRepository _postRepo;
        public BlogController(IPostRepository postRepo, IMapper mapper, IHostingEnvironment environment, ICommentRepository commentRepo)
        {
            _postRepo = postRepo;
            _mapper = mapper;
            hostingEnvironment = environment;
            _commentRepo = commentRepo;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Category()
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

        public IActionResult Post()
        {
           
            return View();
        }
        
        public async Task<JsonResult> GetComments(int postId)
        {
            var comment = await _commentRepo.GetComments(postId);
            return Json(JsonConvert.SerializeObject(comment));
        }

    }
}
