using SelahSeries.Core.Pagination;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository.Interfaces
{
    public interface IBookRepository
    {
        Task<bool> AddBook(Book book);
        Task<PaginatedList<Book>> GetBooks(PaginationParam pageParam);
        IEnumerable<Book> GetHomeBooks();
        Task<Book> GetBook(int bookId);
        Task<bool> DeleteBookAsync(Book book);
        Task<List<Book>> SearchBooks(string searchText);
        Task<bool> UpdateBook(Book book);
    }
}
