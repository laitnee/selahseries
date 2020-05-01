using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SelahSeries.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SelahSeries.Controllers
{
    
    public class BlogController : Controller
    {
        private readonly ICommentRepository _commentRepo;
        public BlogController(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }
        // GET: /<controller>/
        public IActionResult Category()
        {
            return View();
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
