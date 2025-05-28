using Mediator;

namespace DeskBooking.Application.Bookings.Commands.Delete;

public record DeleteBookingByIdCommand(int Id) : IRequest<bool>;