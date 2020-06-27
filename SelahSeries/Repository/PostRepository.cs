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

        public async Task SaveChanges()
        {
            await _selahDbContext.SaveChangesAsync();
        }

        public async Task<Post> GetPost(int postId)
        {
            return await _selahDbContext.Posts
                            .Include(p => p.Category)
                            .Include(p => p.Comments)
                            .Where(post => post.PostId == postId)
                            .FirstOrDefaultAsync();

        }
        public async Task DeletePost(int postId)
        {
            Post post = await _selahDbContext.Posts.Where(p => p.PostId == postId).FirstOrDefaultAsync();
            _selahDbContext.Remove(post);
            
            await _selahDbContext.SaveChangesAsync();
        }
        public async Task<PaginatedList<Post>> GetPosts(PaginationParam pageParam)
        {
            return await _selahDbContext.Posts
                            .Include(p => p.Category)
                            .ToPaginatedListAsync(pageParam);
        }

        public async Task<PaginatedList<Post>> GetPostsByCategory(PaginationParam pageParam, int categoryId)
        {  
            return await _selahDbContext.Posts
                            .Include(p => p.Category)
                                .Where(post => post.CategoryId == categoryId || post.Category.ParentId == categoryId)
                                .ToPaginatedListAsync(pageParam);
        }

        public async Task<PaginatedList<Post>> GetPublishedPosts(PaginationParam pageParam)
        {
            return await _selahDbContext.Posts
                            .Include(p => p.Category)
                            .Where(post => post.Published == true)
                            .ToPaginatedListAsync(pageParam);
        }
        public async Task<List<Post>> GetPublishedDMPosts()
        {
            return await _selahDbContext.Posts
                            .Include(p => p.Category)
                            .Where(post => post.Published == true && post.CreatedAt >= DateTime.Now.AddDays(-7))
                            .OrderBy(p => p.postClap.Claps).Take(5).ToListAsync();
        }
        public async Task<List<Post>> GetTopPosts()
        {
            return await _selahDbContext.Posts
                            .Include(p => p.Category)
                            .Where(post => post.Published == true)
                           .OrderByDescending(x => x.CreatedAt).Take(20)
                           .OrderBy(p => p.postClap.Claps).Take(5).ToListAsync();
        }
        public async Task<PaginatedList<Post>> GetPublishedPostsByCategory(PaginationParam pageParam, int categoryId)
        {
            return await _selahDbContext.Posts
                                    .Where(post => (post.CategoryId == categoryId || post.ParentId == categoryId) && post.Published == true)
                                    .ToPaginatedListAsync(pageParam);
        }
        public async Task<PaginatedList<Post>> GetPublishedPostsByCategory(PaginationParam pageParam, string category)
        {
            int _categoryId = 0;
            
           
                switch (category)
                {
                    case "sports":
                        _categoryId = 1;
                        break;
                    case "relationship_and_marriage":
                    _categoryId = 3;
                        break;
                    case "career":
                        _categoryId = 4;
                        break;
                    case "politics":
                        _categoryId = 2;
                        break;
                    case "general":
                    _categoryId = 5;
                    break;
            }
                return await _selahDbContext.Posts
                                .Include(p => p.Category)
                                    .Where(post => (post.CategoryId == _categoryId || post.ParentId == _categoryId) && post.Published == true)
                                    .ToPaginatedListAsync(pageParam);
            
            
        }
        public async Task<bool> UpdatePost(Post post)
        {
            _selahDbContext.Update<Post>(post);
            return Convert.ToBoolean(await _selahDbContext.SaveChangesAsync());
        }
        public Task ClapPost()
        {
            throw new NotImplementedException();
        }
        public async Task<List<Post>> GetPublishedPostsByClaps(int limit)
        {
            return await _selahDbContext.Posts
                .Include(p => p.postClap)
                .Where(p => p.Published == true && p.postClap.PostClapId == p.PostId)
                .OrderBy(x => x.postClap.Claps)
                .Take(limit)
                .ToListAsync();
        }
        public async Task<List<Post>> SearchPost(String searchText)
        {
            return await _selahDbContext.Posts
                                    .Where(p => p.Title.Contains(searchText) || p.Author.Contains(searchText))
                                    .ToListAsync();
        }

        
    }
}
