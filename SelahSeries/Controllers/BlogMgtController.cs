using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using SelahSeries.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace SelahSeries.Controllers
{
    public class BlogMgtController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment hostingEnvironment;
        static List<Post> BlogPosts = new List<Post>
        {
            new Post
            {
                PostId = 1,
                ParentId = 2,
                Author = "Lekan Agunbiade",
                Title = "Why do we cry",
                Content = "We cry not because we are weak but because we are humans",
                TitleImageUrl = "defaultPostPhoto.jpg",
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
                TitleImageUrl = "defaultPostPhoto.jpg",
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
                Title = "The path of a champion",
                Content = "It takes training, hardwork, tenacity and little talent to forge a path - Olympiad champion",
                TitleImageUrl = "defaultPostPhoto.jpg",
                Published = false,
                CreatedAt = new DateTime(2013, 11, 23),
                ModifiedAt = new DateTime(2019, 05, 09),
                CategoryId = 1,
            }
        };
        public BlogMgtController(IMapper mapper, IHostingEnvironment environment)
        {
            _mapper = mapper;
            hostingEnvironment = environment;
        }
        // GET: BlogMgt
        public ActionResult Index()
        {
            return View(BlogPosts);
        }

        // GET: BlogMgt/Details/5
        public ActionResult Details(int id)
        {
            var blog = BlogPosts.Where(x => x.PostId == id).FirstOrDefault();
            return View(blog);
        }

        // GET: BlogMgt/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogMgt/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] PostCreateViewModel postVM)
        { 

            if (ModelState.IsValid)
            {
                var uploadedImage = "";

                if(postVM.PostPhoto != null) uploadedImage = await ProcessPhoto(postVM.PostPhoto);
                   
                try
                {
                    var post = _mapper.Map<Post>(postVM);
                    post.CreatedAt = DateTime.Now;
                    post.ModifiedAt = DateTime.Now;
                    post.PostId = BlogPosts.Count +1;
                    post.ParentId = 3;
                    post.TitleImageUrl = string.IsNullOrWhiteSpace(uploadedImage)? "defaultPostPhoto.jpg" : uploadedImage;

                    BlogPosts.Add(post);
                
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
           
                return View(postVM);
            
        }

        private async Task<string> ProcessPhoto(IFormFile postPhoto)
        {
            var uniqueFileName = GetUniqueFileName(postPhoto.FileName);
            var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploads, uniqueFileName);

            await postPhoto.CopyToAsync(new FileStream(filePath, FileMode.Create));
            return uniqueFileName;
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                + "_"
                + Guid.NewGuid().ToString().Substring(0, 4)
                + Path.GetExtension(fileName);
        }

        // GET: BlogMgt/Edit/5
        public ActionResult Edit(int id)
        {

            var blogPost = BlogPosts.Where(x => x.PostId == id).FirstOrDefault();
            var blogPostVM = _mapper.Map<PostCreateViewModel>(blogPost);
            return View(blogPostVM);
        }

        // POST: BlogMgt/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm] PostCreateViewModel postVM)
        {
            if (ModelState.IsValid)
            {
                var uploadedImage = "";
                if (postVM.PostPhoto != null) uploadedImage = await ProcessPhoto(postVM.PostPhoto);
                try
                {
                    var post = BlogPosts[postVM.PostId];
                    var editPost = _mapper.Map<Post>(postVM);

                    post = editPost;
                    post.TitleImageUrl = string.IsNullOrWhiteSpace(uploadedImage) ? post.TitleImageUrl
                        : uploadedImage;

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: BlogMgt/Delete/5
        public ActionResult Delete(int id)
        {
            var post = BlogPosts.Where(pos => pos.PostId == id).FirstOrDefault();
            BlogPosts.Remove(post);
            return RedirectToAction(nameof(Index));
        }

        // POST: BlogMgt/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}