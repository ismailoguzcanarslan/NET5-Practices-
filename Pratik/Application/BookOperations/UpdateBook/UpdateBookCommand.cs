using Pratik.DbCntxt;
using Pratik.Entities;
using System;
using System.Linq;

namespace Pratik.Application.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _dbContext;

        public UpdateBookCommand(BookStoreDbContext bookStoreDbContext)
        {
            _dbContext = bookStoreDbContext;
        }

        public bool Handle(UpdateBookModel updateBookModel)
        {
            var book = _dbContext.Books.Where(a => a.Id == updateBookModel.Id);
            if (book is null)
                throw new Exception("book does not exist");

            var updatedBook = new Book
            {
                Id = updateBookModel.Id,
                GenreId = updateBookModel.GenreId,
                PageCount = updateBookModel.PageCount,
                Title = updateBookModel.Title,
            };
            _dbContext.Books.Update(updatedBook);
            _dbContext.SaveChanges();

            return true;
        }
    }

    public class UpdateBookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
    }
}
