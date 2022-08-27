using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pratik.Entities;
using System;
using System.Linq;

namespace Pratik.DbCntxt
{
    public class BookStoreSeed
    {
        public static void Initial(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    //context.Genres.AddRange(
                    //    new Genre
                    //    {
                    //        Name = "Action and Adventure.",
                    //        IsActive = true,

                    //    },
                    //    new Genre
                    //    {
                    //        Name = "Classics.",
                    //        IsActive = false,
                    //    },
                    //    new Genre
                    //    {
                    //        Name = "Comic Book or Graphic Novel.",
                    //        IsActive = true,
                    //    },
                    //    new Genre
                    //    {
                    //        Name = "Detective and Mystery.",
                    //        IsActive = true,
                    //    },
                    //    new Genre
                    //    {
                    //        Name = "Fantasy.",
                    //        IsActive = true,
                    //    },
                    //    new Genre
                    //    {
                    //        Name = "Historical Fiction.",
                    //        IsActive = false,
                    //    },
                    //    new Genre
                    //    {
                    //        Name = "Historical.",
                    //        IsActive = true,
                    //    }
                    //);
                    //context.SaveChanges();
                    return;
                }

                //context.Books.AddRange(
                //    new Book
                //    {
                //        GenreId = 1,
                //        Title = "Arsen Lupen",
                //        PageCount = 178,
                //        PublishDate = DateTime.Now.AddYears(-6)
                //    },
                //    new Book
                //    {
                //        GenreId = 2,
                //        Title = "Sherlock",
                //        PageCount = 220,
                //        PublishDate = DateTime.Now.AddYears(-8)
                //    },
                //    new Book
                //    {
                //        GenreId = 3,
                //        Title = "Dune",
                //        PageCount = 850,
                //        PublishDate = DateTime.Now.AddYears(-5)
                //    }
                //);

                //context.SaveChanges();
            }
        }
    }
}
