using Microsoft.EntityFrameworkCore;
using Pratik.Entities;

namespace Pratik.DbCntxt
{
    public interface IBookStoreDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Genre> Genres { get; set; }
        int SaveChanges();
    }
}
