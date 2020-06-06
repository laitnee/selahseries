using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Models
{
    public class Book
    {
        public Book()
        {

            ModifiedAt = DateTime.Now;
        }
        public int BookId { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        public string Description { get; set; }

        [StringLength(100)]
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string Price { get; set; }
       
        public bool IsHardBook { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public HardBook HardBook { get; set; }

        public SoftBook SoftBook { get; set; }
    }
}
