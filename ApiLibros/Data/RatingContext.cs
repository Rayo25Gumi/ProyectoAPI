using Microsoft.EntityFrameworkCore;
using MiApiSQLite.Models;

namespace MiApiSQLite.Data
{
    public class RatingContext : DbContext
    {
        public RatingContext(DbContextOptions<RatingContext> options)
            : base(options)
        {
        }
        public DbSet<Ratings> Ratings { get; set; }

    }
}