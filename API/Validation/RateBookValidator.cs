using API.DTOs;
using FluentValidation;

namespace API.Validation;

public class RateBookValidator : AbstractValidator<RatingDto>
{
    public RateBookValidator()
    {
        RuleFor(x => x.Score).NotEmpty().NotNull().InclusiveBetween(1, 5);
    }
}