using API.DTOs;
using FluentValidation;

namespace API.Validation;

public class SaveReviewValidator : AbstractValidator<ReviewDto>
{
    public SaveReviewValidator()
    {
        RuleFor(x => x.Message).NotEmpty().NotNull();
    }
}