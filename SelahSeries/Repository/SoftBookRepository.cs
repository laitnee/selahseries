using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SelahSeries.Core.Pagination;
using SelahSeries.Data;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;

namespace SelahSeries.Repository
{
    public class SoftBookRepository : ISoftBookRepository
    {
        private SelahSeriesDataContext _selahDbContext;
        public SoftBookRepository(SelahSeriesDataContext selahDbContext)
        {
            _selahDbContext = selahDbContext;
        }
        public async Task<bool> AddSoftBook(SoftBook softBook)
        {
            await _selahDbContext.AddAsync(softBook);
            return Convert.ToBoolean(
                await _selahDbContext.SaveChangesAsync());
        }

        public async Task<bool> DeleteBook(SoftBook softBook)
        {
            _selahDbContext.Remove(softBook);
            return Convert.ToBoolean(
                await _selahDbContext.SaveChangesAsync());
        }

        public async Task<SoftBook> GetSoftBook(int softBookId) => await _selahDbContext.SoftBooks
                                                    .Where(sb => sb.SoftBookId == softBookId)
                                                    .FirstOrDefaultAsync();

        public async Task<PaginatedList<SoftBook>> GetSoftBooksAsync(PaginationParam pageParam) =>
            await _selahDbContext.SoftBooks
              .ToPaginatedListAsync(pageParam.PageIndex, pageParam.Limit, pageParam.SortColoumn);
    
}
}
