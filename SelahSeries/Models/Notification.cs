using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        
        public string Title { get; set; }
        public string Link { get; set; }

        public string Description { get; set; }
        public bool Read { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
