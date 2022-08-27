using FluentValidation;

namespace Pratik.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreValidator()
        {
            RuleFor(a => a.GenreId).GreaterThan(0);
            RuleFor(a=>a.model.Name).NotEmpty().MinimumLength(3);
        }
    }
}
