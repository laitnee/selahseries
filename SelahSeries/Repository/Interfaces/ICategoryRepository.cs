using SelahSeries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository
{
    public interface ICategoryRepository
    {
        Task<bool> AddCategory(Category category);
        Task<Category> GetCategory(int id);
        Task<List<Category>> GetCategoriesAsync(); 
    }
}
