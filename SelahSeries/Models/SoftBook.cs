using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Models
{
    public class SoftBook
    {
        public int SoftBookId { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(50)]
        public string Author { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(100)]
        public string ImageUrl { get; set; }
        [StringLength(100)]
        public string Location { get; set; }
        public int Downloads { get; set; }
        public int CategoryId { get; set; }
    }
}
