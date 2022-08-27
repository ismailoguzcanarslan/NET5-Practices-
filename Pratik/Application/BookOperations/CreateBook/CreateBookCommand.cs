using AutoMapper;
using Pratik.DbCntxt;
using Pratik.Entities;
using System;
using System.Linq;

namespace Pratik.Application.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateBookModel Model { get; set; }

        public CreateBookCommand(BookStoreDbContext bookStoreDbContext, IMapper mapper)
        {
            _dbContext = bookStoreDbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var isExist = _dbContext.Books.SingleOrDefault(a => a.Title == Model.Title);
            if (isExist is not null)
                throw new InvalidOperationException("The book already exist.");

            var newBook = _mapper.Map<Book>(Model);

            //var newBook = new Book()
            //{
            //    GenreId = Model.GenreId,
            //    PageCount = Model.PageCount,
            //    PublishDate = Model.PublishDate,
            //    Title = Model.Title,
            //};

            _dbContext.Books.Add(newBook);
            _dbContext.SaveChanges();
        }
    }

    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
