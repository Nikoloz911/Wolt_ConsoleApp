using FluentValidation;
using Wolt_ConsoleApp.Models;

namespace Wolt_ConsoleApp.Validators;
internal class AddRestaurantValidator : AbstractValidator<Restaurants>
{
    public AddRestaurantValidator()
    {
        RuleFor(x => x.RestaurantName)
        .NotEmpty().WithMessage("Restaurant Name is required.")
        .MinimumLength(3).WithMessage("Restaurant Name must be at least 3 characters.")
        .MaximumLength(50).WithMessage("Restaurant Name must be at most 50 characters.");
        // Restaurant Blance, Rating, DeliveryAvailable
        RuleFor(x => x.RestaurantBalance)
            .NotEmpty().WithMessage("Restaurant Balance is required.")
            .GreaterThanOrEqualTo(0).WithMessage("Restaurant Balance must be greater than 0.");
        RuleFor(x => x.Rating)
            .NotEmpty().WithMessage("Rating is required.")
            .InclusiveBetween(0, 10).WithMessage("Rating must be between 0 and 10.");
        RuleFor(x => x.DeliveryAvailable)
            .NotEmpty().WithMessage("Delivery Available is required.");

    }
}
