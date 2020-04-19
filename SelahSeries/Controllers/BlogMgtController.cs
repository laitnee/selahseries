using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelahSeries.Models;

namespace SelahSeries.Controllers
{
    public class BlogMgtController : Controller
    {
        static List<Post> BlogPosts = new List<Post>
        {
            new Post
            {
                PostId = 1,
                ParentId = 2,
                Author = "Lekan Agunbiade",
                Title = "Why do we cry",
                Content = "We cry not because we are weak but because we are humans",
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
                Title = "The path of a champion",
                Content = "It takes training, hardwork, tenacity and little talent to forge a path - Olympiad champion",
                TitleImageUrl = "images/me.jpg",
                Published = false,
                CreatedAt = new DateTime(2013, 11, 23),
                ModifiedAt = new DateTime(2019, 05, 09),
                CategoryId = 1,
            }
        };
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
        public ActionResult Create([FromForm] Post post)
        {
            try
            {
                // TODO: Add insert logic here
                post.CreatedAt = DateTime.Now;
                post.ModifiedAt = DateTime.Now;
                post.PostId = BlogPosts.Count +1;
                post.ParentId = 3;
                post.TitleImageUrl = "images/me.jpg";
                BlogPosts.Add(post);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogMgt/Edit/5
        public ActionResult Edit(int id)
        {
            var blog = BlogPosts.Where(x => x.PostId == id).FirstOrDefault();
            return View(blog);
        }

        // POST: BlogMgt/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] Post postForm)
        {
            try
            {
                // TODO: Add update logic here
                BlogPosts[id+1] = postForm;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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