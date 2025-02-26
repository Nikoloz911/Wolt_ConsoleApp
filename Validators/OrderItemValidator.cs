using FluentValidation;
using Wolt_ConsoleApp.Models;
namespace Wolt_ConsoleApp.Validators;
internal class OrderItemValidator : AbstractValidator<OrderItem>
{
    public OrderItemValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("Order ID is required")
            .GreaterThan(0).WithMessage("Order ID must be a positive number");
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("Product ID is required")
            .GreaterThan(0).WithMessage("Product ID must be a positive number");
        RuleFor(x => x.TotalPrice)
            .NotEmpty().WithMessage("Total Price is required")
            .GreaterThan(0).WithMessage("Total Price must be a positive number");
        RuleFor(x => x.Quantity)
            .NotEmpty().WithMessage("Quantity is required")
            .GreaterThan(0).WithMessage("Quantity must be a positive number");
        RuleFor(x => x.OrderDate)
            .NotEmpty().WithMessage("Order Date is required");
    }
}
