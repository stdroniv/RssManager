using FluentValidation;
using RssApi.BLL.DTOs;

namespace RssApi.Configuration.Validators;

public class UserForAuthenticationDtoValidator: AbstractValidator<UserForAuthenticationDto>
{
    public UserForAuthenticationDtoValidator()
    {
        RuleFor(it => it.UserName)
            .NotEmpty();
        
        RuleFor(it => it.Password)
            .NotEmpty();
    }
}