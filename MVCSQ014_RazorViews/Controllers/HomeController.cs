using Microsoft.AspNetCore.Mvc;
using MVCSQ014_RazorViews.Models;
using MVCSQ014_RazorViews.Services;
using MVCSQ014_RazorViews.ViewModels;
using System.Diagnostics;
using System.Security.Cryptography.Xml;

namespace MVCSQ014_RazorViews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService bookService;

        public HomeController(ILogger<HomeController> logger, IBookService bookService)
        {
            _logger = logger;
            this.bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await bookService.GetBooksAsync();

            var bookItems = new List<BookItemViewModel>();

            foreach (var book in books)
            {
                bookItems.Add(new BookItemViewModel
                {
                    Id = book.Id,
                    Name = book.Name,
                    ISBN = book.ISBN,
                    Author = book.Author,
                    Portrait = book.Portrait,
                    TotalPages = book.TotalPages,
                });
            }

            return View(bookItems);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}