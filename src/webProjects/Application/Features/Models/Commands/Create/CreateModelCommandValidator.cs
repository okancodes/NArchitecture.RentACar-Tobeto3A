using Application.Features.Models.Constants;
using FluentValidation;

namespace Application.Features.Models.Commands.Create;

public class CreateModelCommandValidator : AbstractValidator<CreateModelCommand>
{
    public CreateModelCommandValidator()
    {
        RuleFor(b => b.Name).NotEmpty().WithMessage(ModelValidatorMessages.NameNotBlank);
        RuleFor(b => b.Name).MinimumLength(3);
    }
}