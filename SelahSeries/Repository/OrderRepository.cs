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
    public class OrderRepository : IOrderRepository
    {
        private SelahSeriesDataContext _selahDbContext;
        public OrderRepository(SelahSeriesDataContext selahDbContext)
        {
            _selahDbContext = selahDbContext;
        }
        public async Task<bool> AddOrder(Order order)
        {
            await _selahDbContext.AddAsync(order);
            return Convert.ToBoolean(await _selahDbContext.SaveChangesAsync());
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
            return await _selahDbContext.Orders
                            .Where(order => order.OrderId == orderId)
                            .FirstOrDefaultAsync();
        }

        public async Task<PaginatedList<Order>> GetOrders(PaginationParam pageParam)
        {
            return await _selahDbContext.Orders
                        .ToPaginatedListAsync(pageParam.PageIndex, pageParam.Limit, pageParam.SortColoumn);
        }
    }
}
