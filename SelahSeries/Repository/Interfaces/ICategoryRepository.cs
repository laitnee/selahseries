using SelahSeries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository
{
    interface ICategoryRepository
    {
        Task<Category> GetCategory(int id);
        Task<List<Category>> GetCategoriesAsync(); 
    }
}
