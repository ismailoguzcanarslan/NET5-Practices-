using FluentValidation;
using Pratik.Common;
using System;

namespace Pratik.Application.BookOperations.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(a => a.Model.GenreId).NotEmpty().WithMessage("Invalid value for GenreId");
            RuleFor(a => a.Model.PageCount).NotEmpty().GreaterThan(0).LessThan(12000).WithMessage("Page count must between 0-12000");
            RuleFor(a => a.Model.PublishDate).NotEmpty().LessThan(DateTime.Now).WithMessage("You can not set the publish date as a future date");
            RuleFor(a => a.Model.Title).NotEmpty().MinimumLength(4).WithMessage("Title must longer than four character");
        }
    }
}
