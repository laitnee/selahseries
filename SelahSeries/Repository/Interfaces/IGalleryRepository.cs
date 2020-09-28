using SelahSeries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository.Interfaces
{
    public interface IGalleryRepository
    {
        Task<bool> AddPicture(Picture picture);
        List<Picture> GetPictures();
        Task<Picture> GetPicture(int pictureId);
        Task<bool> DeletePictureAsync(Picture picture);
        Task<bool> UpdatePicture(Picture picture);
    }
}
