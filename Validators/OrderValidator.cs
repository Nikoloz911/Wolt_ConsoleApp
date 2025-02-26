using FluentValidation;
using Wolt_ConsoleApp.Models;
using Wolt_ConsoleApp.Enums;
namespace Wolt_ConsoleApp.Validators;
internal class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required")
            .GreaterThan(0).WithMessage("User ID must be a positive number");

        RuleFor(x => x.RestaurantId)
            .NotEmpty().WithMessage("Restaurant ID is required")
            .GreaterThan(0).WithMessage("Restaurant ID must be a positive number");

        RuleFor(x => x.OrderStatus)
            .NotEmpty().WithMessage("Order Status is required")
            .IsEnumName(typeof(ORDER_ENUM), caseSensitive: false)
            .WithMessage("Invalid order status");   
    }
}
