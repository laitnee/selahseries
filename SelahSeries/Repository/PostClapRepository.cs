using Microsoft.EntityFrameworkCore;
using SelahSeries.Data;
using SelahSeries.Models;
using SelahSeries.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository
{
    public class PostClapRepository : IPostClapRepository
    {
        private SelahSeriesDataContext _selahDbContext;
        public PostClapRepository(SelahSeriesDataContext selahDbContext)
        {
            _selahDbContext = selahDbContext;
        }
        public async Task<int> Clap(int clapNumber, int postId)
        {
            var postClap = await _selahDbContext.PostClaps.Where(clap => clap.PostClapId == postId).FirstOrDefaultAsync();
            if (postClap != null)
            {
                postClap.Claps += clapNumber;
                _selahDbContext.Update(postClap);
                await _selahDbContext.SaveChangesAsync();
                return await GetClaps(postId);
            }

            postClap = new PostClap
            {
                PostClapId = postId,
                Claps = clapNumber
            };
            _selahDbContext.Add(postClap);
            await _selahDbContext.SaveChangesAsync();
            return await GetClaps(postId);
        }

        public async Task<int> GetClaps(int postId)
        {
            var postClap = await _selahDbContext.PostClaps.Where(pc => pc.PostClapId == postId).FirstOrDefaultAsync();
            if (postClap != null) return postClap.Claps;
            return 0;
        }
    }
}
