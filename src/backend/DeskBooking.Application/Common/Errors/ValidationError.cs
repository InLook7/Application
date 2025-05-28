using FluentResults;

namespace DeskBooking.Application.Common.Errors;

public class ValidationError(string message) : Error(message)
{
}