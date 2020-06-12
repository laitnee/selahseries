using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using SelahSeries.Repository.Interfaces;
using SelahSeries.ViewModels;

namespace SelahSeries.Controllers
{
    public class BookMgtController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IBookRepository _bookRepo;
        public BookMgtController(IBookRepository bookRepo, IMapper mapper, IHostingEnvironment environment)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
            hostingEnvironment = environment;
        }
        // GET: BookMgt
        [Route("BookMgt")]
        [Route("BookMgt/Index")]
        public async Task<ActionResult> Index()
        {
            var pageParam = new PaginationParam
            {
                PageIndex = 1,
                Limit = 20,
                SortColoumn = "CreatedAt"
            };
            if (TempData.ContainsKey("Alert"))
            {
                ViewBag.Alert = TempData["Alert"].ToString();
            }
            if (TempData.ContainsKey("Error"))
            {
                ViewBag.Error = TempData["Error"].ToString();
            }
            var books = await _bookRepo.GetBooks(pageParam);
            return View(books.Source);
        }
        // GET: BookMgt/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookMgt/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] BookCreateViewModel bookVM)
        {
            if (ModelState.IsValid)
            {
                var uploadedImage = "";
                var uploadedBook = "";
                if (bookVM.BookPhoto != null) uploadedImage = await ProcessPhoto(bookVM.BookPhoto);
                if (bookVM.BookUpload != null) uploadedBook= await ProcessPhoto(bookVM.BookUpload);

                try
                {
                    var book = _mapper.Map<Book>(bookVM);
                    book.CreatedAt = DateTime.Now;
                    book.ImageUrl = uploadedImage;
                    book.BookUrl = uploadedBook;

                    book.Price = string.IsNullOrWhiteSpace(book.Price) ? "-" : book.Price ;

                    if (await _bookRepo.AddBook(book))
                    {
                        TempData["Alert"] = "Book Created Successfully";
                        return RedirectToAction(nameof(Index));
                    }

                    ViewBag.Error = "Unable to add book, please try again or contact administrator";
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Unable to add book, please try again or contact administrator";
                    return View();
                }
            }
            ViewBag.Error = "Please correct the error(s) in Form";
            return View(bookVM);

        }

        private async Task<string> ProcessPhoto(IFormFile photo)
        {
            var uniqueFileName = GetUniqueFileName(photo.FileName);
            var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploads, uniqueFileName);

            await photo.CopyToAsync(new FileStream(filePath, FileMode.Create));
            return uniqueFileName;
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                + "_"
                + Guid.NewGuid().ToString().Substring(0, 4)
                + Path.GetExtension(fileName);
        }

        // GET: BookMgt/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            var book = await _bookRepo.GetBook(id);
            var blogPostVM = _mapper.Map<BookCreateViewModel>(book);
            return View(blogPostVM);
        }

        // POST: BookMgt/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm] BookCreateViewModel bookVM)
        {
            if (ModelState.IsValid)
            {
                var uploadedImage = "";
                var editBook = _mapper.Map<Book>(bookVM);
                if (bookVM.BookPhoto != null) uploadedImage = await ProcessPhoto(bookVM.BookPhoto);
                try
                {
                    if (!string.IsNullOrWhiteSpace(uploadedImage)) editBook.ImageUrl = uploadedImage;

                    await _bookRepo.UpdateBook(editBook);
                    TempData["Alert"] = "Book Edited Successfully";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Unable to add book, please try again or contact administrator";
                    return View();
                }
            }
            ViewBag.Error = "Please correct the error(s) in Form";
            return View();
        }
        // GET: BlogMgt/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var book = _bookRepo.GetBook(id);
                await _bookRepo.DeleteBookAsync(book.Result);
                TempData["Alert"] = "Book Deleted Successfully";
                return RedirectToAction(nameof(Index));


            }
            catch
            {
                TempData["Error"] = "Error occured: Unable to delete book";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: BookMgt/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}