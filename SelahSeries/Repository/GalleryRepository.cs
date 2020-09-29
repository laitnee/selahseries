using SelahSeries.Data;
using SelahSeries.Models;
using SelahSeries.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository
{
    public class GalleryRepository : IGalleryRepository
    {
        private SelahSeriesDataContext _selahDbContext;

        public GalleryRepository(SelahSeriesDataContext selahDbContext)
        {
            _selahDbContext = selahDbContext;
        }

        public async Task<bool> AddPicture(Picture picture)
        {
            await _selahDbContext.AddAsync(picture);
            return Convert.ToBoolean(await _selahDbContext.SaveChangesAsync());
        }

        public async Task<bool> DeletePictureAsync(Picture picture)
        {
            _selahDbContext.Remove(picture);
            return Convert.ToBoolean(await _selahDbContext.SaveChangesAsync());
        }

        public List<Picture> GetPictures()
        {
            return _selahDbContext.Pictures.OrderByDescending(x => x.CreatedAt).ToList();
        }

        public async Task<Picture> GetPicture(int pictureId)
        {
            return await _selahDbContext.Pictures.FindAsync(pictureId);
        }

        public async Task<bool> UpdatePicture(Picture picture)
        {
            _selahDbContext.Update<Picture>(picture);
            return Convert.ToBoolean(await _selahDbContext.SaveChangesAsync());
        }
    }
}
