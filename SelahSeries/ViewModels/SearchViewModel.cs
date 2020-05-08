using SelahSeries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.ViewModels
{
    public class SearchViewModel
    {
        public List<Post> Posts { get; set; }
        public List<Book> Books { get; set; }
    }
}
