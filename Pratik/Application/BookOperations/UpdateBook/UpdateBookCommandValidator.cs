using FluentValidation;

namespace Pratik.Application.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookModel>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(a => a.GenreId).NotEmpty().WithMessage("Invalid value for GenreId");
            RuleFor(a => a.PageCount).NotEmpty().GreaterThan(0).LessThan(12000).WithMessage("Page count must between 0-12000");
            RuleFor(a => a.Title).NotEmpty().MinimumLength(4).WithMessage("Title must longer than four character");
        }
    }
}
