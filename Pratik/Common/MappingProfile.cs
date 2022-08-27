using AutoMapper;
using Pratik.Application.BookOperations.CreateBook;
using Pratik.Application.BookOperations.GetBooks;
using Pratik.Application.GenreOperations.GetGenres;
using Pratik.Entities;

namespace Pratik.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();

            CreateMap<Book, BookViewModel>().ForMember(dest=>dest.Genre, opt=>opt.MapFrom(src=> src.Genre.Name));

            CreateMap<Genre, GenreViewModel>();
        }
    }
}
