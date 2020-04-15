
using SelahSeries.Core.Pagination;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository
{
    interface IPostRepository
    {
        Task<bool> AddPost(Post post);
        Task<Post> GetPost(int postId);
        Task<PaginatedList<Post>> GetPosts(PaginationParam pageParam);
        Task<PaginatedList<Post>> GetPostsByCategory(PaginationParam pageParam, int categoryId);
        Task<PaginatedList<Post>> GetPublishedPosts(PaginationParam pageParam);
        Task<PaginatedList<Post>> GetPublishedPostsByCategory(PaginationParam pageParam, int categoryId);
        Task<bool> UpdatePost(Post post);
        Task ClapPost();
    }
}
