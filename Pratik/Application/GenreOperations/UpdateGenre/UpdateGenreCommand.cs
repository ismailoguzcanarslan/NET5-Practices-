using Pratik.DbCntxt;
using System.Linq;

namespace Pratik.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public UpdateGenreModel model { get; set; }

        private readonly BookStoreDbContext _bookStoreDbContext;

        public UpdateGenreCommand(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public void Handle()
        {
            var genre = _bookStoreDbContext.Genres.SingleOrDefault(a => a.Id == GenreId);

            if (genre is not null)
            {
                genre.IsActive = model.IsActice;
                genre.Name = model.Name;
                _bookStoreDbContext.Genres.Update(genre);
                _bookStoreDbContext.SaveChanges();
            }
        }

        public class UpdateGenreModel
        {
            public string Name { get; set; }
            public bool IsActice { get; set; } = true;
        }
    }
}
