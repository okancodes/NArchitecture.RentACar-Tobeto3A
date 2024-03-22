using Application.Features.Cars.Constants;
using FluentValidation;

namespace Application.Features.Cars.Commands.Create;

public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(b => b.ModelYear).NotEmpty().WithMessage(CarValidatorMessages.NameNotBlank);
        RuleFor(b => b.ModelYear).ExclusiveBetween(1950, DateTime.Now.Year).WithMessage(CarValidatorMessages.YearNotCorrect); 
    }
}