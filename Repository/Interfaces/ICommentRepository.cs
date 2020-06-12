using SelahSeries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository
{
    public interface ICommentRepository
    {
        Task<bool> AddComment(Comment comment);
        //Task<Comment> GetCommentAsync(int commentId);
        Task<List<Comment>> GetSubComments(int postId, int commentId);
        Task<List<Comment>> GetComments(int postId);
    }
}
