using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public string Time { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
