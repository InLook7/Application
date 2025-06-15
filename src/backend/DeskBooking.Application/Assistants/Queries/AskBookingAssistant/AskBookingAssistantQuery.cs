using Mediator;

namespace DeskBooking.Application.Assistants.Queries.AskBookingAssistant;

public record AskBookingAssistantQuery(string Question) : IRequest<string>;