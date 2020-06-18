using Microsoft.AspNetCore.Http;
using SelahSeries.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.ViewModels
{
    public class BookCreateViewModel
    {
        public int BookId { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Author { get; set; }
        public IFormFile BookPhoto { get; set; }

        public IFormFile BookUpload { get; set; }

        [Required]
        public string Description { get; set; }

        [StringLength(100)]
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
        

        public string Price { get; set; }
        public bool IsHardBook { get; set; }

       
    }
}
