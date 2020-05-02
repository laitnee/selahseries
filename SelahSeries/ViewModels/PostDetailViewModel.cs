using SelahSeries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.ViewModels
{
    public class PostDetailViewModel
    {
        public Post post { get; set; }
        public Comment Comment { get; set; }
    }
}
