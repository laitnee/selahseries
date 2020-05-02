using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SelahSeries.Models;
using SelahSeries.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SelahSeries.Controllers
{
    
    public class BlogController : Controller
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IPostRepository _postRepo;
        public BlogController(ICommentRepository commentRepo, IPostRepository postRepo)
        {
            _commentRepo = commentRepo;
            _postRepo = postRepo;
        }
        // GET: /<controller>/
        public IActionResult Category()
        {
            return View();
        }
        
        [Route("blog/post/{postId}")]
        public async Task<IActionResult> Post(int postId)
        {
            var post = await _postRepo.GetPost(postId);
            var comments = await _commentRepo.GetComments(postId);
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> PostComment([FromForm] Comment comment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    comment.PostId = 1;
                    comment.CreatedAt = DateTime.UtcNow;
                    if(!await _commentRepo.AddComment(comment)) return View();
                    RedirectToAction("Post", "Blog");
                } catch { return View(); }
                

            }
            return View();
            }

        [Route("comments/{postId}")]
        [HttpGet]
        public async Task<JsonResult> GetComments(int postId)
        {
            var comment = await _commentRepo.GetComments(postId);
            return Json(JsonConvert.SerializeObject(comment));
        }



    }
}
