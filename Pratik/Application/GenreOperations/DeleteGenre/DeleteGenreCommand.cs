using Pratik.DbCntxt;
using System.Linq;

namespace Pratik.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }

        private readonly BookStoreDbContext _bookStoreDbContext;

        public DeleteGenreCommand(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public void Handle()
        {
            var genre = _bookStoreDbContext.Genres.SingleOrDefault(a=>a.Id == GenreId);

            if(genre is not null)
            {
                _bookStoreDbContext.Genres.Remove(genre);
                _bookStoreDbContext.SaveChanges();
            }
        }
    }
}
