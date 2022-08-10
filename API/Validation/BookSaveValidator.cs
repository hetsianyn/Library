using API.DTOs;
using FluentValidation;

namespace API.Validation;

public class BookCreationDtoValidator : AbstractValidator<BookCreationDto>
{
    public BookCreationDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().NotNull();
        // RuleFor(x => x.Cover).NotEmpty().NotNull();
        // RuleFor(x => x.Content).NotEmpty().NotNull();
        RuleFor(x => x.Author).NotEmpty().NotNull();
        RuleFor(x => x.Genre).NotEmpty().NotNull();
    }    
}