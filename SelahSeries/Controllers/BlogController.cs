using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SelahSeries.Models;
using SelahSeries.Repository;
using SelahSeries.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SelahSeries.Controllers
{
    
    public class BlogController : Controller
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IPostRepository _postRepo;
        private readonly IPostClapRepository    _postClapRepo;
        public BlogController(ICommentRepository commentRepo, IPostRepository postRepo, IPostClapRepository postClapRepo)
        {
            _commentRepo = commentRepo;
            _postRepo = postRepo;
            _postClapRepo = postClapRepo;
        }
        // GET: /<controller>/
        public IActionResult Category()
        {
            return View();
        }
        
        [Route("blog/post/{postId}")]
        public async Task<IActionResult> Post(int postId)
        {
            try
            {
                var post = await _postRepo.GetPost(postId);
                var comments = await _commentRepo.GetComments(postId);

                var postDetailViewModel = new PostDetailViewModel() { Post = post, CommentList = comments };
                return View(postDetailViewModel);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostComment([FromForm] Comment comment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(comment.Author)) comment.Author = "Anonymous";
                    comment.CreatedAt = DateTime.UtcNow;
                    await _commentRepo.AddComment(comment);
                }
                catch { return View(); }
                
            }
            return RedirectToAction("Post", "Blog", new { postId = comment.PostId });
        }

        [Route("clap")]
        [HttpPost]
        public async Task<JsonResult> AddClaps([FromBody]PostClapVM postClapVM)
        {
            int result = 0;
            try
            {
                if (postClapVM.ClapNumber > 0 && postClapVM.PostId > 0) result = await _postClapRepo.Clap(postClapVM.ClapNumber, postClapVM.PostId);
                return Json(JsonConvert.SerializeObject(new { Claps = result }));
            }
            catch (Exception ex)
            {
                return Json(JsonConvert.SerializeObject(new { }));
            }
           
        }

        [Route("/{postId}/claps")]
        [HttpGet]
        public async Task<JsonResult> GetClaps(int postId)
        {
            try
            {
                var result = 0;
                if (postId > 0) result = await _postClapRepo.GetClaps(postId);
                return Json(JsonConvert.SerializeObject(new { Claps = result }));
            }
            catch (Exception ex)
            {
                return Json(JsonConvert.SerializeObject(new { }));
            }

        }


    }
}
