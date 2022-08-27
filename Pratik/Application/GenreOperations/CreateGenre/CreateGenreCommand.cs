using AutoMapper;
using Pratik.DbCntxt;
using Pratik.Entities;
using System;
using System.Linq;

namespace Pratik.Application.GenreOperations.CreateGenre
{
    public class CreateGenreCommand
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateGenreModel _model { get; set; }

        public CreateGenreCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(a=>a.Name == _model.Name);

            if (genre is not null)
                throw new InvalidOperationException();

            genre = new Genre
            {
                Name = _model.Name,
                IsActive = true
            };
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }

    public class CreateGenreModel
    {

        public string Name { get; set; }
    }
}
