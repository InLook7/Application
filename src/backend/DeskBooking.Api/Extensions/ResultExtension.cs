using FluentResults;
using DeskBooking.Api.Responses;
using DeskBooking.Application.Common.Errors;

namespace DeskBooking.Api.Extensions;

public static class ResultExtensions
{
    public static bool IsNotFound<T>(this Result<T> result)
    {
        return result.HasError<NotFoundError>();
    }
    
    public static bool IsValidationError<T>(this Result<T> result)
    {
        return result.HasError<ValidationError>();
    }

    public static ErrorResponse ToErrorResponse<T>(this Result<T> result)
    {
        var messages = result.Errors.Select(e => e.Message).ToList();

        return new ErrorResponse(messages);
    }
}