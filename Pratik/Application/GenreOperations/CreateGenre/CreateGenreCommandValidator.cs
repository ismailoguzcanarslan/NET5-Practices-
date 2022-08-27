using FluentValidation;

namespace Pratik.Application.GenreOperations.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(command => command._model.Name).NotEmpty().MinimumLength(4);
        }
    }
}
