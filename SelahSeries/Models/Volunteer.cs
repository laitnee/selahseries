using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Models
{
    public class Volunteer
    {
        public int VolunteerId { get; set; }
        public string FullName { get; set; }
        //public string AgeRange { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
