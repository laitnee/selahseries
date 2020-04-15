using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SelahSeries.Core.Pagination;
using SelahSeries.Data;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;

namespace SelahSeries.Repository
{
    public class PostRepository : IPostRepository
    {
        private SelahSeriesDataContext _selahDbContext;
        public PostRepository(SelahSeriesDataContext selahDbContext)
        {
            _selahDbContext = selahDbContext;
        }
        public async Task<bool> AddPost(Post post)
        {
            await _selahDbContext.AddAsync(post);
            return Convert.ToBoolean(
                await _selahDbContext.SaveChangesAsync());
        }



        public async Task<Post> GetPost(int postId)
        {
            return await _selahDbContext.Posts
                            .Where(post => post.PostId == postId)
                            .FirstOrDefaultAsync();

        }

        public async Task<PaginatedList<Post>> GetPosts(PaginationParam pageParam)
        {
            return await _selahDbContext.Posts
                            .ToPaginatedListAsync(pageParam.PageIndex, pageParam.Limit, pageParam.SortColoumn);
        }

        public async Task<PaginatedList<Post>> GetPostsByCategory(PaginationParam pageParam, int categoryId)
        {
            return await _selahDbContext.Posts
                                .Where(post => post.CatergoryId == categoryId || post.Category.ParentId == categoryId)
                                .ToPaginatedListAsync(pageParam.PageIndex, pageParam.Limit, pageParam.SortColoumn);
        }
        public async Task<PaginatedList<Post>> GetPublishedPosts(PaginationParam pageParam)
        {
            return await _selahDbContext.Posts
                            .Where(post => post.Published == true)
                            .ToPaginatedListAsync(pageParam.PageIndex, pageParam.Limit, pageParam.SortColoumn);
        }

        public async Task<PaginatedList<Post>> GetPublishedPostsByCategory(PaginationParam pageParam, int categoryId)
        {
            return await _selahDbContext.Posts
                                .Where(post => (post.CatergoryId == categoryId ||  post.ParentId == categoryId) && post.Published == true)
                                .ToPaginatedListAsync(pageParam.PageIndex, pageParam.Limit, pageParam.SortColoumn);
        }
        public async Task<bool> UpdatePost(Post post)
        {
            _selahDbContext.Update(post);
            return Convert.ToBoolean(await _selahDbContext.SaveChangesAsync());
        }
        public Task ClapPost()
        {
            throw new NotImplementedException();
        }
    }
}
