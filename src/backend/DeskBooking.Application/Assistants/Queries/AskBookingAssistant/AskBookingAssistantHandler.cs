using Mediator;
using DeskBooking.Application.Common.Interfaces;
using DeskBooking.Domain.Interfaces;

namespace DeskBooking.Application.Assistants.Queries.AskBookingAssistant;

public class AskBookingAssistantHandler
    : IRequestHandler<AskBookingAssistantQuery, string>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookingAssistant _bookingAssistant;

    public AskBookingAssistantHandler(
        IUnitOfWork unitOfWork,
        IBookingAssistant bookingAssistant)
    {
        _unitOfWork = unitOfWork;
        _bookingAssistant = bookingAssistant;
    }

    public async ValueTask<string> Handle(AskBookingAssistantQuery query, CancellationToken cancellationToken)
    {
        var bookings = await _unitOfWork.BookingRepository.GetAllWithDetailsAsync();

        var bookingsInfo = bookings.Select(b => 
            $"📆 {b.StartDate} - {b.Workspace.WorkspaceType.Name} for {(b.Workspace.Capacity == 1 ? "person" : "people")} ({b.StartTime}-{b.EndTime})");
        var bookingsInfoFormatted = string.Join("\n", bookingsInfo);

        var question = $"{query.Question} \n {bookingsInfoFormatted} \n Answer briefly.";

        return await _bookingAssistant.GetAnswerAsync(question);
    }
}