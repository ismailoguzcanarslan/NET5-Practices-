using AutoMapper;
using Pratik.DbCntxt;
using System.Collections.Generic;
using System.Linq;

namespace Pratik.Application.GenreOperations.GetGenres
{
    public class GetGenresQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenresQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenreViewModel> Handle()
        {
            var genres = _context.Genres.Where(a => a.IsActive == true).OrderBy(a=>a.Id).ToList();

            List<GenreViewModel> obj = _mapper.Map<List<GenreViewModel>>(genres);

            return obj;
        }
    }

    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
