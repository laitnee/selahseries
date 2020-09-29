using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Models
{
    public class Testimonial
    {
        public int TestimonialId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
