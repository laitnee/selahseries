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
using SelahSeries.Repository;
using SelahSeries.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using SelahSeries.Services;
using System.Text.RegularExpressions;

namespace SelahSeries.Controllers
{

    public class BlogMgtController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IPostRepository _postRepo;
        private readonly IEmailService _emailService;
        private readonly ISubscriptionRepository _subRepo;
        public IBackgroundTaskQueue _queue;

        public BlogMgtController(IPostRepository postRepo, IMapper mapper, IHostingEnvironment environment, 
            IEmailService emailService, IBackgroundTaskQueue queue, ISubscriptionRepository subscriptionRepo )
        {
            _postRepo = postRepo;
            _mapper = mapper;
            hostingEnvironment = environment;
            _emailService = emailService;
            _queue = queue;
            _subRepo = subscriptionRepo;
        }
        // GET: BlogMgt
        [Route("[controller]")]
        public async Task<ActionResult> Index([FromQuery]int pageIndex = 1)
        {
            Post post = new Post();
            var pageParam = new PaginationParam
            {
                PageIndex = pageIndex,
                Limit = 20,
                SortColoumn = "CreatedAt"
            };
            if (TempData.ContainsKey("Alert"))
            {
                ViewBag.Alert = TempData["Alert"].ToString();
            }
            if (TempData.ContainsKey("Error"))
            {
                ViewBag.Error = TempData["Error"].ToString();
            }
            var posts = await _postRepo.GetPosts(pageParam);
            ViewBag.PostCount = posts.TotalCount;
            ViewBag.CurrentPage = posts.Currentpage;
            return View(posts.Source);
        }

        // GET: BlogMgt/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var post = await _postRepo.GetPost(id);
            return View(post);
        }

        // GET: BlogMgt/Create
        public async Task<ActionResult> Create()
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
                string defaultPostPhoto = "";
                if (postVM.PostPhoto != null) uploadedImage = await ProcessPhoto(postVM.PostPhoto);

                try
                {

                    var post = _mapper.Map<Post>(postVM);
                    post.CreatedAt = DateTime.Now;
                    if (post.CategoryId == 1)
                    {
                        defaultPostPhoto = "sportsPhoto.jpg";
                    }

                    else if (post.CategoryId == 3)
                    {
                        defaultPostPhoto = "careerPhoto.jpg";
                    }
                    else if (post.CategoryId == 4)
                    {
                        defaultPostPhoto = "politicsPhoto.jpg";
                    }
                    else
                    {
                        defaultPostPhoto = "marriagePhoto.jpg";
                    }

                    post.TitleImageUrl = string.IsNullOrWhiteSpace(uploadedImage) ? defaultPostPhoto : uploadedImage;


                    if (await _postRepo.AddPost(post))
                    {
                        TempData["Alert"] = "Post Created Successfully";
                        if(post.Published) await SendEmailToSuscribers(post);
                        return RedirectToAction(nameof(Index));
                    }

                    ViewBag.Error = "Unable to add post, please try again or contact administrator";
                    return View();
                }
                catch (Exception ex)
                { 
                    ViewBag.Error = "Unable to add post, please try again or contact administrator";
                    return View();
                }
            }
            ViewBag.Error = "Please correct the error(s) in Form";


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

        private async Task SendEmailToSuscribers(Post post)
        {
            var userImagePath = Path.Combine(hostingEnvironment.WebRootPath, "uploads", post.TitleImageUrl);

            List<EmailSubscription> emailSubscribers = await _subRepo.GetPostSuscribers();

            string message = ProcessMessage(post.Content);
            //post.Content.Length > 300 ? post.Content.Substring(0, 300) : post.Content.Substring(0, post.Content.Length);

            var subscribersList = emailSubscribers.Select(x => x.SubscriberEmail).ToList();
            _queue.QueueBackgroundWorkItem(async token => { 
                await Task.Run(() => _emailService.SendSubscriptionMail(subscribersList, post.Title, message, post.PostId, userImagePath, "postemail"));
            });
            
        }

        private string ProcessMessage(string content)
        {
            var matches = Regex.Matches(content, "(?<=>)([^<]+)(?=<)");
            var parsedContent = string.Join(" ", matches).Replace('\\', ' ');
            if(parsedContent.Length > 300){
                var subContent = parsedContent.Substring(0, 300).Trim();
                parsedContent = subContent.Substring(0, subContent.LastIndexOf(" "));
            }

            return parsedContent;
        }

        // GET: BlogMgt/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            var blogPost = await _postRepo.GetPost(id);
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
                var editPost = _mapper.Map<Post>(postVM);
                if (postVM.PostPhoto != null) uploadedImage = await ProcessPhoto(postVM.PostPhoto);
                try
                {
                    if (!string.IsNullOrWhiteSpace(uploadedImage)) editPost.TitleImageUrl = uploadedImage;

                    await _postRepo.UpdatePost(editPost);
                    TempData["Alert"] = "Post Edited Successfully";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Unable to add post, please try again or contact administrator";
                    return View();
                }
            }
            ViewBag.Error = "Please correct the error(s) in Form";
            return View();
        }

        // GET: BlogMgt/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                await _postRepo.DeletePost(id);
                TempData["Alert"] = "Post Deleted Successfully";
                return RedirectToAction(nameof(Index));


            }
            catch
            {
                TempData["Error"] = "Error occured: Unable to delete post";
                return RedirectToAction(nameof(Index));
            }
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