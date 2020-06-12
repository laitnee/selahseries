using Microsoft.EntityFrameworkCore;
using SelahSeries.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SelahSeries.Core.Pagination
{
    public static class IQueryableExtensions
    {
        public static async Task<PaginatedList<T>> ToPaginatedListAsync<T>(this IQueryable<T> query, int pageIndex,
            int limit, string sortColumn)
        {
            var totalCount = await query.CountAsync();
            if (!string.IsNullOrWhiteSpace(sortColumn))
            {
                var collection = query
                    .OrderBy(sortColumn, false)
                    .Skip((pageIndex - 1) * limit)
                    .Take(limit);
                return new PaginatedList<T>(collection, totalCount);
            }
            else
            {
                var collection = query.Skip((pageIndex - 1) * limit).Take(limit);
                return new PaginatedList<T>(collection, totalCount);
            }
        }
        public static async Task<PaginatedList<T>> ToPaginatedListAsync<T>(this IQueryable<T> query,
            PaginationParam pageParam) where T : class
        {
            return await query.ToPaginatedListAsync(pageParam.PageIndex, pageParam.Limit, pageParam.SortColoumn);
        }

        public static async Task<PaginatedList<T>> ToPaginatedListAsync<T, TKey>(this IQueryable<T> query,
            int pageIndex, int limit, Expression<Func<T, TKey>> keySelector) where T : class
        {
            return await query.ToPaginatedListAsync(pageIndex, limit, keySelector.Name);
        }
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string orderByProperty,
           bool desc)
        {
            string command = desc ? "OrderByDescending" : "OrderBy";
            var type = typeof(TEntity);
            var property = type.GetProperty(orderByProperty);
            if (orderByProperty == null)
                return source;



            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<TEntity>(resultExpression);
        }
    }






}
