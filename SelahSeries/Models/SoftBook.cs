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
        public string Location { get; set; }
        public int Downloads { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
