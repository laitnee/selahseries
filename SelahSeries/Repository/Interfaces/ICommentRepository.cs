using SelahSeries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository
{
    interface ICommentRepository
    {
        Task<bool> AddComment(Comment comment);
        Task<Comment> GetCommentAsync(int commentId);
        Task<List<Comment>> GetSubComments(int commentId);
        Task<List<Comment>> GetComments();
    }
}
