using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SelahSeries.Data;
using SelahSeries.Models;

namespace SelahSeries.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private SelahSeriesDataContext _selahDbContext;
        public CommentRepository(SelahSeriesDataContext selahDbContext)
        {
            _selahDbContext = selahDbContext;
        }
        public async Task<bool> AddComment(Comment comment)
        {
            await _selahDbContext.AddAsync(comment);
            return Convert.ToBoolean(await _selahDbContext.SaveChangesAsync());
        }

        public async Task<Comment> GetCommentAsync(int postId)
        {
            return await _selahDbContext.Comments
                                 .Where(com => com.CommentId == postId)
                                 .FirstOrDefaultAsync();
        }

        public async Task<List<Comment>> GetComments(int postId)
        {
            return await _selahDbContext.Comments
                                 .Include(c => c.ChildrenComments
                                                .Where(cC => c.CommentId == cC.ParentId).Count())  
                                 .ToListAsync();
        }
        public async Task<List<Comment>> GetSubComments(int postId, int commentId)
        {
            return await _selahDbContext.Comments
                     .Where(com => com.ParentId == commentId)
                     .Include(comment => comment.ChildrenComments
                                    .Where(childComments => comment.CommentId == childComments.ParentId).Count())
                    .ToListAsync();
        }

    }
}
