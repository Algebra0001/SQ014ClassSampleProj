using Microsoft.EntityFrameworkCore;
using SimpleBookAPI.Data.Entities;

namespace SimpleBookAPI.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options):base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
