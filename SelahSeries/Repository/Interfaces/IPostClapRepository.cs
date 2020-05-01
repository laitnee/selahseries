using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository.Interfaces
{
    interface IPostClapRepository
    {
        Task<bool> Clap(int clapNumber);
    }
}
