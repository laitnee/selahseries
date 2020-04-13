using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Models
{
    public class HardBookCategory
    {
        public int BookId { get; set; }
        public HardBook HardBook { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
