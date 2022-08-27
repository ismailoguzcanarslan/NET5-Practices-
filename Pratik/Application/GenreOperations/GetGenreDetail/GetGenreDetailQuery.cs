using AutoMapper;
using Pratik.Application.GenreOperations.GetGenres;
using Pratik.DbCntxt;
using System;
using System.Linq;

namespace Pratik.Application.GenreOperations.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreViewModel Handle()
        {
            var genre = _context.Genres.FirstOrDefault(a => a.IsActive == true && a.Id == Id);

            if (genre is null)
                throw new InvalidOperationException("genre not found");

            return _mapper.Map<GenreViewModel>(genre);

        }
    }
}
