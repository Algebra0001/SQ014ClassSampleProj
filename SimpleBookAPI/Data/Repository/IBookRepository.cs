using SimpleBookAPI.Data.Entities;

namespace SimpleBookAPI.Data.Repository
{
    public interface IBookRepository
    {
        Task<Book> AddAsync(Book entity);
        Task<bool> DeleteAsync(Book entity);
        Task<Book> UpdateAsync(Book entity);
        Task<Book> GetBookAsync(string BookId);
        Task<IEnumerable<Book>> GetBooksAsync();
        IEnumerable<Book> Paginate(IEnumerable<Book> books, int page, int pageSize);


    }
}
