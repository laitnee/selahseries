using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Models
{
    public class HardBook
    {
        [Key]
        public int HarbookId { get; set; }
        public double Price { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
