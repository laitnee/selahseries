using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        

        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        [StringLength(50)]
        public string Author { get; set; }
        [StringLength(50)]
        public string Email { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public int? ParentCommentId { get; set; }
        public Comment Parent { get; set; }
        public ICollection<Comment> Replies { get; set; }
    }
}
