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
    public class HardBookRepository : IHardBookRepository
    {
        private SelahSeriesDataContext _selahDbContext;
        public HardBookRepository(SelahSeriesDataContext selahDbContext)
        {
            _selahDbContext = selahDbContext;
        }
        public async Task<bool> AddHardBook(HardBook hardBook)
        {
            await _selahDbContext.AddAsync(hardBook);
            return Convert.ToBoolean(
                await _selahDbContext.SaveChangesAsync());
        }

        public async Task<bool> DeleteBookAsync(HardBook hardBook)
        {
            _selahDbContext.Remove(hardBook);
            return Convert.ToBoolean(
                await _selahDbContext.SaveChangesAsync());
        }

        public async Task<HardBook> GetHardBook(int hardBookId) => await _selahDbContext.HardBooks
                                                    .Where(hb => hb.HardBookId == hardBookId)
                                                    .FirstOrDefaultAsync();

        

        public async Task<PaginatedList<HardBook>> GetHardBooks(PaginationParam pageParam) =>
            await _selahDbContext.HardBooks
              .ToPaginatedListAsync(pageParam.PageIndex, pageParam.Limit, pageParam.SortColoumn);
    }
}
