using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.ViewModels
{
    public class GalleryListViewModel
    {
        public int PictureId { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public IFormFile Photo { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
