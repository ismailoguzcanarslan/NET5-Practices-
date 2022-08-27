using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Pratik.Application.BookOperations.CreateBook;
using Pratik.Application.BookOperations.GetBook;
using Pratik.Application.BookOperations.GetBooks;
using Pratik.Application.BookOperations.UpdateBook;
using Pratik.DbCntxt;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pratik.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly IBookStoreDbContext _bookStoreDbContext;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext bookStoreDbContext, IMapper mapper)
        {
            _bookStoreDbContext = bookStoreDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            GetBooksQuery query = new GetBooksQuery(_bookStoreDbContext, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<BookViewModel> Get(int id)
        {
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_bookStoreDbContext, _mapper);
                var result = query.Handle(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Create(CreateBookModel book)
        {
            CreateBookCommand command = new CreateBookCommand(_bookStoreDbContext, _mapper);

            command.Model = book;

            CreateBookCommandValidator validationRules = new CreateBookCommandValidator();
            validationRules.ValidateAndThrow(command);

            command.Handle();
            return Ok();

        }

        [HttpPut]
        public ActionResult Update(UpdateBookModel book)
        {
            UpdateBookCommand updateBookCommand = new UpdateBookCommand(_bookStoreDbContext);

            try
            {
                UpdateBookCommandValidator validationRules = new UpdateBookCommandValidator();
                validationRules.ValidateAndThrow(book);

                var result = updateBookCommand.Handle(book);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            var isExist = _bookStoreDbContext.Books.FirstOrDefault(a => a.Id == id);
            if (isExist is not null)
            {
                _bookStoreDbContext.Books.Remove(isExist);
                _bookStoreDbContext.SaveChanges();
                return Ok();
            }
            return BadRequest("book does not exist");
        }
    }
}
