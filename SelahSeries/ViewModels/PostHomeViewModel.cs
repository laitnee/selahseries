using SelahSeries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.ViewModels
{
    public class PostHomeViewModel
    {
        public Post Post { get; set; }
        public List<PostListViewModel> DontMiss { get; set; }
        public List<PostListViewModel> TopPosts { get; set; }
        public int TotalPostCount { get; set; }
        public int CurrentPage { get; set; }
        public List<PostListViewModel> LatestArticle { get; set; }
        public List<Book> Books { get; set; }
        public List<Post> TopStories { get; set; }
    }
}
