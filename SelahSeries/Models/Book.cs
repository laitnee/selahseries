using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(100)]
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public bool IsHardBook { get; set; }

        public HardBook HardBook { get; set; }

        public SoftBook SoftBook { get; set; }
    }
}
