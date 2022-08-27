using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pratik.Application.BookOperations.GetBooks;
using Pratik.Common;
using Pratik.DbCntxt;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pratik.Application.BookOperations.GetBook
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBookDetailQuery(BookStoreDbContext bookStoreDbContext, IMapper mapper)
        {
            _dbContext = bookStoreDbContext;
            _mapper = mapper;
        }

        public BookViewModel Handle(int id)
        {
            var book = _dbContext.Books.Include(a=>a.Genre).Where(a => a.Id == id).FirstOrDefault();

            if (book is null)
                throw new Exception("book not found");
            var bookDto = _mapper.Map<BookViewModel>(book);
            //{
            //    Title = book.Title,
            //    Genre = ((GenreEnum)book.GenreId).ToString(),
            //    PageCount = book.PageCount,
            //    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
            //};
            
            return bookDto;
        }
    }
}
