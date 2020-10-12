using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Models
{
    public class EmailSubscription
    {
        
        public int EmailSubscriptionId { get; set; }
        
        public string SubscriberEmail { get; set; }
        public bool ConfirmEmail { get; set; }
        
        public string ConfirmationCode { get; set; }
    }
}
