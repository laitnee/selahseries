using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SelahSeries.Data;
using SelahSeries.Models;

namespace SelahSeries.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private SelahSeriesDataContext _selahDbContext;
        public CategoryRepository(SelahSeriesDataContext selahDbContext)
        {
            _selahDbContext = selahDbContext;
        }
        public async Task<bool> AddCategory(Category category)
        {
            await _selahDbContext.AddAsync(category);
            return Convert.ToBoolean(await _selahDbContext.SaveChangesAsync());
        }
        public async Task<List<Category>> GetCategoriesAsync() => await _selahDbContext.Categories
            .Where(cat => cat.ParentId != null).ToListAsync();

        public Task<Category> GetCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
