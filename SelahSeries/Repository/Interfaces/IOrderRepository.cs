using SelahSeries.Core.Pagination;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository
{
    interface IOrderRepository
    {
        Task<bool> AddOrder(Order order);
        Task<PaginatedList<Order>> GetOrders(PaginationParam pageParam);
        Task<Order> GetOrderAsync(int orderId);
    }
}
