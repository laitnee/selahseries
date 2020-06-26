using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
namespace SelahSeries.ViewModels
{
    public class PostCreateViewModel
    {
        public int PostId { get; set; }
        [Required]
        [StringLength(50)]
        public string Author { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public IFormFile PostPhoto { get; set; }
        [Required]
        public string Content { get; set; }
        public string TitleImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Published { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public string FacebookPostLink { get; set; }
        public string TwitterPostLink { get; set; }
        public string LinkedInPostLink { get; set; }
    }
}
