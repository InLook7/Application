namespace DeskBooking.Application.Common.Interfaces;

public interface IBookingAssistant
{
    Task<string> GetAnswerAsync(string question);
}