using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Models
{
    public class Picture
    {
        public int PictureId { get; set; }
        public string Name { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
