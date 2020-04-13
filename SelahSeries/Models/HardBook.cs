using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Models
{
    public class HardBook
    {
        public int HardBookId { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(50)]
        public string Author { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [StringLength(100)]
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int CatergoryId { get; set; }

    }
}
