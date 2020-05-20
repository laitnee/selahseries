using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int quantity { get; set; }
        public int ShippingAddress { get; set; }
        public double Price { get; set; }
        public int BookId { get; set; }
        public HardBook HardBook { get; set; }
    }
}
