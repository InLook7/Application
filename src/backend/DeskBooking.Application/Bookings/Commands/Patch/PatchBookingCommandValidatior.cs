using FluentValidation;

namespace DeskBooking.Application.Bookings.Commands.Patch;

public class PatchBookingCommandValidatior : AbstractValidator<PatchBookingCommand>
{
    public PatchBookingCommandValidatior()
    {
        RuleFor(x => x.StartDate)
            .LessThanOrEqualTo(x => x.EndDate)
            .WithMessage("Start date must be before or equal to end date.");

        RuleFor(x => x.StartTime)
            .LessThan(x => x.EndTime)
            .WithMessage("Start time must be before end time.");

        RuleFor(x => x.StartDate)
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now))
            .WithMessage("Start date cannot be in the past.");
    }
}