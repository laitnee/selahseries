using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Models
{
    public class PostClap
    {
        
        public int ClapId { get; set; }
        public Post Post { get; set; }
        public int Claps { get; set; }
    }
}
