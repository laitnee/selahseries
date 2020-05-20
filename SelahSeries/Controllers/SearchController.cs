using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelahSeries.Repository;
using SelahSeries.Repository.Interfaces;
using SelahSeries.ViewModels;

namespace SelahSeries.Controllers
{
    public class SearchController : Controller
    {
        private readonly IBookRepository _bookRepo;
        private readonly IPostRepository _postRepo;

        public SearchController(IBookRepository bookRepo, IPostRepository postRepo)
        {
            _postRepo = postRepo;
            _bookRepo = bookRepo;
        }
        
        public async Task<IActionResult> SearchAll([FromQuery]string searchText)
        {
            var resultingPosts = await _postRepo.SearchPost(searchText);
            var resultingBooks = await _bookRepo.SearchBooks(searchText);

            SearchViewModel searchViewModel = new SearchViewModel();

            searchViewModel.Books = resultingBooks;
            searchViewModel.Posts = resultingPosts;
            return View("SearchResultView",searchViewModel);

        }

        public async Task<IActionResult> SearchBooks([FromQuery]string searchText)
        {
            var resultingBooks = await _bookRepo.SearchBooks(searchText);
            SearchViewModel searchViewModel = new SearchViewModel();
            searchViewModel.Books = resultingBooks;
            return View("SearchResultView", searchViewModel);
        }

        public async Task<IActionResult> SearchPosts([FromQuery]string searchText)
        {
            var resultingPosts = await _postRepo.SearchPost(searchText);
            SearchViewModel searchViewModel = new SearchViewModel();
            searchViewModel.Posts = resultingPosts;
            return View("SearchResultView", searchViewModel);
        }
    }
}