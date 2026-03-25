using System;
using FluentValidation;
using minimal_users_api.Dtos;

namespace minimal_users_api.Validators;

public class CreateUserValidator: AbstractValidator<CreateUserDTO>
{
  public CreateUserValidator()
  {
    RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
    RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is required");
    RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email is not valid");
    RuleFor(x => x.Age).GreaterThan(0).WithMessage("Age must be greater than 0").LessThanOrEqualTo(150).WithMessage("Age must be less than or equal to 150");
  }
}
