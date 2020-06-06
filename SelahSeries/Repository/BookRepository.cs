using Microsoft.EntityFrameworkCore;
using SelahSeries.Core.Pagination;
using SelahSeries.Data;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using SelahSeries.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Repository
{
    public class BookRepository : IBookRepository
    {
        private SelahSeriesDataContext _selahDbContext;
        public BookRepository(SelahSeriesDataContext selahDbContext)
        {
            _selahDbContext = selahDbContext;
        }
        public async Task<bool> AddBook(Book book)
        {
            await _selahDbContext.AddAsync(book);
            return Convert.ToBoolean(await _selahDbContext.SaveChangesAsync());
        }

        public async Task<bool> DeleteBookAsync(Book book)
        {
            _selahDbContext.Remove(book);
            return Convert.ToBoolean( await _selahDbContext.SaveChangesAsync());
        }

        public async Task<Book> GetBook(int bookId)
        {
            return await _selahDbContext.Books
                                        .Include(bk => bk.HardBook)
                                        .Include(bk => bk.SoftBook)
                                        .Where(hb => hb.BookId == bookId)
                                        .FirstOrDefaultAsync();
        }

        public  IEnumerable<Book> GetHomeBooks()
        {
            return  _selahDbContext.Books
                                        .Include(bk => bk.HardBook)
                                        .Include(bk => bk.SoftBook).OrderByDescending(x => x.CreatedAt).Take(12);

        }


        public async Task<PaginatedList<Book>> GetBooks(PaginationParam pageParam)
        {
            return await _selahDbContext.Books
                                        .Include(bk => bk.HardBook)
                                        .Include(bk => bk.SoftBook).ToPaginatedListAsync(pageParam);
                            
        }
   
        public async Task<List<Book>> SearchBooks(string searchText)
        {
            return await _selahDbContext.Books
                                    .Where(p => p.Title.Contains(searchText) || p.Author.Contains(searchText))
                                    .ToListAsync();
        }

        public async Task<bool> UpdateBook(Book book)
        {
            _selahDbContext.Update<Book>(book);
            return Convert.ToBoolean(await _selahDbContext.SaveChangesAsync());
        }
    }
}
