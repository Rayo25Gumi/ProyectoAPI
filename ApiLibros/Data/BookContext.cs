using Microsoft.EntityFrameworkCore;
using MiApiSQLite.Models;

namespace MiApiSQLite.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}