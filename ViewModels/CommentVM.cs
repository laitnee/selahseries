using SelahSeries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.ViewModels
{
    public class CommentVM
    {

            public IEnumerable<Comment> Comments { get; set; }
            public int ParentId { get; set; }

    }
}
