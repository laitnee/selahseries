using SelahSeries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.ViewModels
{
    public class PostDetailViewModel
    {
        public Post Post { get; set; }
        public Comment Comment { get; set; }
        public List<Post> RelatedPosts { get; set; }

        public List<Post> TopStories { get; set; }
    }
}
