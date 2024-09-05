using FluentValidation;
using KDSOrderManagement.Models.Dtos;

namespace KDSOrderManagement.Validators
{
    public class OrderValidator : AbstractValidator<OrderDto>
    {
        public OrderValidator() 
        {
            RuleFor(c => c.CustomerName)
                .NotEmpty().WithMessage("Customer name must be provided.")
                .NotNull().WithMessage("Customer name cannot be null.");

            RuleFor(c => c.OrderTime)
                .NotEmpty().WithMessage("Time must be provided.")
                .NotNull().WithMessage("Time cannot be null.");

            RuleFor(c => c.Status)
                .NotEmpty().WithMessage("Status must be provided.")
                .NotNull().WithMessage("Status cannot be null.");
        }
    }
}
