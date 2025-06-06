using FluentValidation;

namespace DeskBooking.Application.Bookings.Commands.Patch;

public class PatchBookingCommandValidatior : AbstractValidator<PatchBookingCommand>
{
    public PatchBookingCommandValidatior()
    {
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