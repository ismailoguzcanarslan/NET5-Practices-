using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Pratik.Application.GenreOperations.CreateGenre;
using Pratik.Application.GenreOperations.DeleteGenre;
using Pratik.Application.GenreOperations.GetGenreDetail;
using Pratik.Application.GenreOperations.GetGenres;
using Pratik.Application.GenreOperations.UpdateGenre;
using Pratik.DbCntxt;
using static Pratik.Application.GenreOperations.UpdateGenre.UpdateGenreCommand;

namespace Pratik.Controllers
{
    [ApiController]
    [Route("genre")]
    public class GenreController : Controller
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetGenres()
        {
            GetGenresQuery getGenres = new GetGenresQuery(_context, _mapper);
            var result = getGenres.Handle();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult GetGenreDetail(int id)
        {
            GetGenreDetailQuery getGenre = new GetGenreDetailQuery(_context, _mapper);
            getGenre.Id = id;
            GenreDetailQueryValidator validator = new GenreDetailQueryValidator();
            validator.ValidateAndThrow(getGenre);

            var result = getGenre.Handle();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Create(CreateGenreModel model)
        {
            CreateGenreCommand create = new CreateGenreCommand(_context, _mapper); 
            create._model = model;

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(create);

            create.Handle();
            return StatusCode(201);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id ,[FromBody] UpdateGenreModel model)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = id;
            command.model = model;
            
            UpdateGenreValidator validator = new UpdateGenreValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            DeleteGenreCommand delete = new DeleteGenreCommand(_context);
            delete.GenreId = id;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(delete);

            delete.Handle();

            return Ok();
        }
    }
}
