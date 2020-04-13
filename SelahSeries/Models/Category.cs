using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Post> Posts {get; set;}
        public ICollection<HardBook> HardBooks { get; set; }
        public ICollection<SoftBook> SoftBooks { get; set; }
    }
}
