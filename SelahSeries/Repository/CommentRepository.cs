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
            return Convert.ToBoolean(
                await _selahDbContext.SaveChangesAsync());
        }

        public async Task<Comment> GetCommentAsync(int commentId) => await _selahDbContext.Comments
                                                    .Where(com => com.CommentId == commentId)
                                                    .FirstOrDefaultAsync();

        public async Task<List<Comment>> GetComments() => await _selahDbContext.Comments.ToListAsync();

        public async Task<List<Comment>> GetSubComments(int commentId) => await _selahDbContext.Comments
                                                                .Where(com => com.CommentId == commentId)
                                                                    .ToListAsync();

    }
}
