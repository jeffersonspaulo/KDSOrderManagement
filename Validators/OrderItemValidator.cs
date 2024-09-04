using FluentValidation;
using KDSOrderManagement.Models;

namespace KDSOrderManagement.Validators
{
    public class OrderItemValidator : AbstractValidator<OrderItemDto>
    {
        public OrderItemValidator() 
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Customer name must be provided.")
                .NotNull().WithMessage("Customer name cannot be null.");

            RuleFor(c => c.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
        }
    }
}
