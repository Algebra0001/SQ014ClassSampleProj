using Microsoft.EntityFrameworkCore;
using SimpleBookAPI.Data.Entities;

namespace SimpleBookAPI.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext context;

        public BookRepository(BookContext context)
        {
            this.context = context;
        }
        public async Task<Book> AddAsync(Book entity)
        {
            await context.Books.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await context.Books.ToListAsync();
        }

        public async Task<bool> DeleteAsync(Book entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Book> GetBookAsync(string BookId)
        {
            var book = await context.Books.FirstOrDefaultAsync(x => x.Id == BookId);
            if(book != null)
            {
                return book;
            }

            return null;
        }

        public IEnumerable<Book> Paginate(IEnumerable<Book> books, int page, int pageSize)
        {
            return books.Skip(page -1 * pageSize).Take(pageSize);
        }

        public async Task<Book> UpdateAsync(Book entity)
        {
            context.Books.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
