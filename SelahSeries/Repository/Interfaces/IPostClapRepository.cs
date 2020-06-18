using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository
{
    public interface IPostClapRepository
    {
        Task<int> Clap(int clapNumber, int postId);
        Task<int> GetClaps(int postId);
    }
}
