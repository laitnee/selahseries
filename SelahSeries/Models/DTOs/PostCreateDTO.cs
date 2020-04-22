using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Models.DTOs
{
    public class PostCreateDTO
    {

        public string Author { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        public FormFile PostPhoto { get; set; }
        public string Content { get; set; }
        [StringLength(100)]
        public bool Published { get; set; }
        public int CategoryId { get; set; }
    }
}
