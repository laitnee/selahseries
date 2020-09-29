using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Core.Pagination
{
    public class PaginatedList<T>
    {
        public PaginatedList(IQueryable<T> source, int count, int currPage)
        {
            TotalCount = count;
            Currentpage = currPage;
            try
            {
                Source = source.ToList<T>();
            }
            catch(Exception ex)
            {
                Source = new List<T>();
            }
        }
        public List<T> Source { get; set; }
        public int Currentpage { get; set; }
        public int TotalCount { get; set; }
    }
}
