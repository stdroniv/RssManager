using FluentValidation;
using RssApi.BLL.DTOs;

namespace RssApi.Configuration.Validators;

public class UserForRegistrationDtoValidator: AbstractValidator<UserForRegistrationDto>
{
    public UserForRegistrationDtoValidator(IDateTimeProvider dateTimeProvider)
    {
        RuleFor(i => i.FirstName)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(i => i.LastName)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(i => i.Email)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(i => i.Password)
            .NotEmpty()
            .MaximumLength(25);
        
        RuleFor(i => i.Username)
            .NotEmpty()
            .MaximumLength(25);

        RuleFor(i => i.DateOfBirth)
            .GreaterThan(dateTimeProvider.Now.AddYears(120));
    }
}