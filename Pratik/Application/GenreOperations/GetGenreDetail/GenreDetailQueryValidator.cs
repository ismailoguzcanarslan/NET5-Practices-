using FluentValidation;

namespace Pratik.Application.GenreOperations.GetGenreDetail
{
    public class GenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public GenreDetailQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
