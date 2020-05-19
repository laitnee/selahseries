using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.ViewModels
{
    public class PostHomeViewModel
    {
        public List<PostListViewModel> DontMiss { get; set; }
        public List<PostListViewModel> LatestArticle { get; set; }
    }
}
