using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int ParentId { get; set; }

        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        [StringLength(50)]
        public string Author { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}
