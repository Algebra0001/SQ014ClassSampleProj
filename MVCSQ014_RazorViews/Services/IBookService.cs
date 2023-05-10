using MVCSQ014_RazorViews.Models;

namespace MVCSQ014_RazorViews.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookAsync();  
    }
}
