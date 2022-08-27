using Microsoft.EntityFrameworkCore;
using Pratik.Entities;

namespace Pratik.DbCntxt
{
    public class BookStoreDbContext : DbContext, IBookStoreDbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
