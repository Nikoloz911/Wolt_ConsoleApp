using FluentValidation;
using Wolt_ConsoleApp.Models;
namespace Wolt_ConsoleApp.Validators;
internal class EditRestaurantValidator : AbstractValidator<Restaurants>
{
    public EditRestaurantValidator()
    {
        RuleFor(x => x.RestaurantName)
            .NotEmpty().WithMessage("Restaurant Name is required")
            .MaximumLength(40).WithMessage("Restaurant Name must not exceed 40 characters"); // Limit
        RuleFor(x => x.RestaurantBalance)
            .NotEmpty().WithMessage("Restaurant Balance is required")
            .LessThanOrEqualTo(999999).WithMessage("Restaurant Balance cannot exceed 999,999") // Limit
            .GreaterThanOrEqualTo(0).WithMessage("Restaurant Balance must be greater than or equal to 0");
        RuleFor(x => x.Rating)
            .NotEmpty().WithMessage("Restaurant Rating is required")
            .LessThanOrEqualTo(10).WithMessage("Restaurant Rating cannot exceed 10") // Limit
            .GreaterThanOrEqualTo(0).WithMessage("Restaurant Rating must be greater than or equal to 0");
        RuleFor(x => x.DeliveryAvailable)
            .NotNull().WithMessage("Delivery Availability is required");
        
    }
}
