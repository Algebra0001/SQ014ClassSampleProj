using Microsoft.AspNetCore.Mvc;
using MVCSQ014_RazorViews.Services;

namespace MVCSQ014_RazorViews.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public IActionResult SingleBook(int Id)
        {
            var bookId = Id;
            return View();
        }
    }
}
