using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using SelahSeries.Repository;
using SelahSeries.Services;
using SelahSeries.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SelahSeries.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IPostRepository _postRepo;
        private readonly IPostClapRepository    _postClapRepo;
        private readonly IConfiguration _configuration;
        public BlogController(IConfiguration configuration, ICommentRepository commentRepo, IPostRepository postRepo, IPostClapRepository postClapRepo)
        {
            _configuration = configuration;
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
                //var comments = await _commentRepo.GetComments(postId);

                PaginationParam relPgParam = new PaginationParam() { PageIndex = 1, Limit = 4, SortColoumn = "CreatedAt" };
                var relatedPosts = await _postRepo.GetPublishedPostsByCategory(relPgParam, post.CategoryId);

                
                const int LIMIT = 4;
                var topStories = await _postRepo.GetPublishedPostsByClaps(LIMIT);


                var postDetailViewModel = new PostDetailViewModel() {
                    Post = post,
                    RelatedPosts = relatedPosts.Source,
                    TopStories = topStories
                   };
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
        [Route("fbComments/{postId}/")]
        [HttpGet]
        public async Task<JsonResult> GetFacebookComments(int postId)
        {
            try
            {
                var clientId = _configuration["Facebook:ClientId"];
                var clientSecret = _configuration["Facebook:ClientSecret"];
                FacebookService fb = new FacebookService(clientId, clientSecret);
                var fbcomments = fb.GetCommentsByPageId("276024362504445", 10);
                return Json(JsonConvert.SerializeObject(fbcomments));
            }
            catch (Exception ex)
            {
                return Json(JsonConvert.SerializeObject(new { }));
            }

        }


    }
}
