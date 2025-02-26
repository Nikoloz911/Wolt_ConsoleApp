using FluentValidation;
using Wolt_ConsoleApp.Models;
using Wolt_ConsoleApp.Enums;
namespace Wolt_ConsoleApp.Validators;
internal class PaymentValidator : AbstractValidator<Payment>
{
    public PaymentValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("Order ID is required")
            .GreaterThan(0).WithMessage("Order ID must be a positive number");
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required")
            .GreaterThan(0).WithMessage("User ID must be a positive number");
        RuleFor(x => x.CreditCardId)
            .NotEmpty().WithMessage("Credit Card ID is required")
            .GreaterThan(0).WithMessage("Credit Card ID must be a positive number");
        RuleFor(x => x.TotalAmount)
      .NotEmpty().WithMessage("Total Amount is required")
      .GreaterThan(0).WithMessage("Total Amount must be a positive number")
      .LessThanOrEqualTo(200000).WithMessage("Total Amount cannot exceed 200,000");
            /// LIMIT 200K
        RuleFor(x => x.PaymentStatus)
            .NotEmpty().WithMessage("Payment Status is required")
            .IsEnumName(typeof(PAYMENT_ENUM), caseSensitive: false)
            .WithMessage("Invalid payment status");
    }
}
