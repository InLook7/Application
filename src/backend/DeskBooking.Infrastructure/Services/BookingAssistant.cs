using Microsoft.Extensions.AI;
using DeskBooking.Application.Common.Interfaces;

namespace DeskBooking.Infrastructure.Services;

public class BookingAssistant : IBookingAssistant
{
    private readonly IChatClient _chatClient;

    public BookingAssistant(IChatClient chatClient)
    {
        _chatClient = chatClient;
    }

    public async Task<string> GetAnswerAsync(string question)
    {
        var response = await _chatClient.GetResponseAsync(question);

        return response.Text;
    }
}