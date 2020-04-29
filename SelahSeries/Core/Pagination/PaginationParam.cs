using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Models.DTOs
{
    public class PaginationParam
    {
        public int PageIndex { get; set; }
        public int Limit { get; set; }
        public string SortColoumn { get; set; }
        public string Filter { get; set; }
    }
}
