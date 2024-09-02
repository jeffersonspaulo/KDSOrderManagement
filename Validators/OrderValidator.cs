using FluentValidation;
using KDSOrderManagement.Models.Entities;

namespace KDSOrderManagement.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator() 
        {
            RuleFor(c => c.CustomerName)
                .NotEmpty().WithMessage("Customer name must be provided.")
                .NotNull().WithMessage("Customer name must be provided.");

            RuleFor(c => c.Items)
                .NotEmpty().WithMessage("Items must be added.")
                .NotNull().WithMessage("Items must be added.");

            RuleFor(c => c.OrderTime)
                .NotEmpty().WithMessage("Time must be provided.")
                .NotNull().WithMessage("Time must be provided.");

            RuleFor(c => c.Status)
                .NotEmpty().WithMessage("Status must be provided.")
                .NotNull().WithMessage("Status must be provided.");
        }
    }
}
