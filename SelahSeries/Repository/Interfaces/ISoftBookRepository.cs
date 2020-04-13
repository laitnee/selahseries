using SelahSeries.Core.Pagination;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository
{
    interface ISoftBookRepository
    {
        Task<bool> AddSoftBook (SoftBook  softBook );
        Task<PaginatedList<SoftBook>> GetSoftBooksAsync(PaginationParam pageParam);
        Task<SoftBook> GetSoftBook (int softBookId);
        Task<bool> DeleteBook(SoftBook  softBook );
    }
}
