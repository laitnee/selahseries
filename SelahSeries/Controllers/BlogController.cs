using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SelahSeries.Core.Pagination;
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
        private readonly IMapper _mapper;
        public BlogController(IConfiguration configuration, ICommentRepository commentRepo, IPostRepository postRepo, IPostClapRepository postClapRepo, IMapper mapper)
        {
            _configuration = configuration;
            _commentRepo = commentRepo;
            _postRepo = postRepo;
            _postClapRepo = postClapRepo;
            _mapper = mapper;
        }
        // GET: /<controller>/
        [Route("Blog/Index")]
        [HttpGet("Blog/{pageIndex}")]
        [Route("Blog")]

        public async Task<IActionResult> Index(int pageIndex, string category)
        {
            PostHomeViewModel postHomeVM = new PostHomeViewModel();
            int page = (pageIndex == 0) ? 1 : pageIndex;
            var pageParam = new PaginationParam
            {
                PageIndex = page,
                Limit = 15,
                SortColoumn = "CreatedAt"
            };
            var dontMiss = await  _postRepo.GetPublishedDMPosts();
            var dontMissVM = _mapper.Map<List<PostListViewModel>>(dontMiss);
            postHomeVM.DontMiss = dontMissVM;

            var topPosts = await _postRepo.GetTopPosts();
            var topPostsVM = _mapper.Map<List<PostListViewModel>>(topPosts);
            postHomeVM.TopPosts = topPostsVM;

            PaginatedList<Post> latestArticles;
            if (category == "all" || category == null)
            {
                latestArticles = await _postRepo.GetPublishedPosts(pageParam);
            }
            else
            {
                latestArticles = await _postRepo.GetPublishedPostsByCategory(pageParam, category);
            }
            postHomeVM.TotalPostCount = latestArticles.TotalCount;
            postHomeVM.CurrentPage = latestArticles.Currentpage;

            var latestArticlesVM = _mapper.Map<List<PostListViewModel>>(latestArticles.Source);
            postHomeVM.LatestArticle = latestArticlesVM;

            ViewData["Category"] = category;
            ViewData["PageIndex"] = page;
            return View(postHomeVM);
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
