using FluentValidation;
using KDSOrderManagement.Models;

namespace KDSOrderManagement.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator() 
        {
            RuleFor(c => c.Username)
                .NotEmpty().WithMessage("Username must be provided.")
                .NotNull().WithMessage("Username name must be provided.");

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Items must be added.")
                .NotNull().WithMessage("Items must be added.");
        }
    }
}
