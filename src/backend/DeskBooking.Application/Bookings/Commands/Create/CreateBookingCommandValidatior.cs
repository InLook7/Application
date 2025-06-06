using FluentValidation;

namespace DeskBooking.Application.Bookings.Commands.Create;

public class CreateBookingCommandValidatior : AbstractValidator<CreateBookingCommand>
{
    public CreateBookingCommandValidatior()
    {
        RuleFor(x => x.BookedByName)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must be less than 100 characters.");

        RuleFor(x => x.BookedByEmail)
            .NotEmpty().WithMessage("Email is required.")
            .MaximumLength(100).WithMessage("Email must be less than 100 characters.")
            .EmailAddress().WithMessage("Email address should be in a valid format.");

        RuleFor(x => x.StartDate)
            .LessThanOrEqualTo(x => x.EndDate).WithMessage("Start date must be before or equal to end date.");

        RuleFor(x => x.StartDate)
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now))
            .WithMessage("Start date cannot be in the past.");

        RuleFor(x => x)
            .Must(x => x.StartDate != x.EndDate || x.StartTime < x.EndTime)
            .WithMessage("If booking is for a single day, start time must be before end time.");
    }
}