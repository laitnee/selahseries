using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.ViewModels
{
    public class GalleryCreateViewModel
    {
        public int PictureId { get; set; }
        public string Name { get; set; }       
        public string ImgUrl { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
