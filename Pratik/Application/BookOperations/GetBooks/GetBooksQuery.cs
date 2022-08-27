using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pratik.Common;
using Pratik.DbCntxt;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pratik.Application.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly    BookStoreDbContext _dbContext;

        private readonly IMapper _mapper; 

        public GetBooksQuery(BookStoreDbContext bookStoreDbContext, IMapper mapper)
        {
            _dbContext = bookStoreDbContext;
            _mapper = mapper;
        }

        public IEnumerable<BookViewModel> Handle()
        {
            var books = _dbContext.Books.Include(a=>a.Genre).OrderBy(a => a.Title).ToList();
            List<BookViewModel> vm = _mapper.Map<List<BookViewModel>>(books);
            //foreach (var book in books)
            //{
            //    vm.Add(new BookViewModel()
            //    {
            //        Title = book.Title,
            //        Genre = ((GenreEnum)book.GenreId).ToString(),
            //        PageCount = book.PageCount,
            //        PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
            //    });
            //}

            return vm;
        }
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public string PublishDate { get; set; }
        public int PageCount { get; set; }
        public string Genre { get; set; }
    }
}
