using DatingApp.Application.Dtos.Account;
using FluentValidation;

namespace DatingApp.Infrastructure.ApiDtoValidations
{
  public class UserRegisterDtoValidator : AbstractValidator<RegisterDto>
  {
    public UserRegisterDtoValidator()
    {
      RuleFor(x => x.UserName)
        .NotEmpty();

      RuleFor(x => x.Password)
        .NotEmpty();

    }
  }
}