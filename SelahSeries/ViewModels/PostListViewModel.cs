using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.ViewModels
{
    public class PostListViewModel
    {
        public int PostId { get; set; }
        [Required]
        [StringLength(50)]
        public string Author { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public string TitleImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
