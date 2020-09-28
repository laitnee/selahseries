using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.ViewModels
{
    public class EventCreateViewModel
    {
        public int EventId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        [Required]
        public IFormFile EventPhoto { get; set; }
        [Required]
        public string Description { get; set; }
        [StringLength(100)]
        public string ImgUrl { get; set; }
        public string Time { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
