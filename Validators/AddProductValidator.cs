using FluentValidation;
using Wolt_ConsoleApp.Models;
namespace Wolt_ConsoleApp.Validators;
internal class AddProductValidator : AbstractValidator<Product>
{
    public AddProductValidator()
    {
        RuleFor(x => x.ProductName)
            .NotEmpty().WithMessage("Product Name is required")
            .MaximumLength(100).WithMessage("Product Name must not exceed 100 characters");

        RuleFor(x => x.ProductPrice)
            .NotEmpty().WithMessage("Product Price is required")
            .LessThanOrEqualTo(99999).WithMessage("Product Price cannot exceed 99,999") // Limit
            .GreaterThan(0).WithMessage("Product Price must be greater than 0");

        RuleFor(x => x.IsAvailable)
            .NotNull().WithMessage("Product Availability is required");

        RuleFor(x => x.ProductQuantity)
            .NotEmpty().WithMessage("Product Quantity is required")
            .GreaterThanOrEqualTo(1).WithMessage("Product Quantity must be at least 1");

        RuleFor(x => x.RestaurantsId)
            .NotEmpty().WithMessage("Product Restaurant Id is required")
            .GreaterThan(0).WithMessage("Restaurant Id must be a valid positive number");
    }
}
