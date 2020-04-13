using SelahSeries.Core.Pagination;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository
{
    interface IHardBookRepository
    {
        Task<bool> AddHardBook(HardBook hardBook);
        Task<PaginatedList<HardBook>> GetHardBooks(PaginationParam pageParam);
        Task<HardBook> GetHardBook(int hardBookId);
        Task<bool> DeleteBookAsync(HardBook hardBook);
    }
}
