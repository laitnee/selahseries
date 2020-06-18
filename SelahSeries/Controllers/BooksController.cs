using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SelahSeries.Models.DTOs;
using SelahSeries.Repository.Interfaces;
using SelahSeries.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SelahSeries.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;
        public BooksController(IBookRepository bookRepo, IMapper mapper)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
        }

        // GET: /<controller>/
        [Route("Books/Index")]
        public IActionResult Index(int pageIndex)
        {
            int page = (pageIndex == 0) ? 1 : pageIndex;
            var pageParam = new PaginationParam
            {
                PageIndex = page,
                Limit = 20,
                SortColoumn = "CreatedAt"
            };
            var books = _bookRepo.GetBooks(pageParam).Result;
            //BookListViewModel bookVM = new BookListViewModel();
            //var booksVM = _mapper.Map<List<BookListViewModel>>(books);
            return View(books.Source);
        }

        public IActionResult Cart()
        {
            return View();
        }
    }
}
