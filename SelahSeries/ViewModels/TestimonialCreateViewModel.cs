using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.ViewModels
{
    public class TestimonialCreateViewModel
    {
        public int TestimonialId { get; set; }
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        [Required]
        public IFormFile TestimonyPhoto { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
