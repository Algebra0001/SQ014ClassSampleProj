using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleBookAPI.Data.Repository;

namespace SimpleBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes ="Bearer")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepo;

        public BookController(IBookRepository bookRepo)
        {
            this.bookRepo = bookRepo;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll(int page, int pageSize)
        {
            page = page < 1 ? 1:page;
            pageSize = pageSize < 10 ? 10: pageSize;

            var books = await bookRepo.GetBooksAsync();
            var pagedBooks = bookRepo.Paginate(books, page, pageSize);

            if(pagedBooks != null && pagedBooks.Any())
            {
                return Ok(pagedBooks);
            }

            return NotFound("No records found for books");
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetBook(int Id)
        {
            var book = await bookRepo.GetBookAsync(Id.ToString());

            if (book != null)
            {
                return Ok(book);
            }

            return NotFound("No record found for book");
        }
    }
}
