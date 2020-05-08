using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Core.Pagination
{
    public class PaginatedList<T>
    {
        public PaginatedList(IQueryable<T> source, int count)
        {
            TotalCount = count;
            try
            {
                Source = source.ToList();
            }
            catch(Exception ex)
            {
                Source = new List<T>();
            }
        }
        public List<T> Source { get; set; }
        public int TotalCount { get; set; }
    }
}
