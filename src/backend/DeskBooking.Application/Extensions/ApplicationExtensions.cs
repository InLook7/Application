using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using DeskBooking.Application.Bookings.Commands.Create;
using DeskBooking.Application.Bookings.Commands.Patch;

namespace DeskBooking.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped);

        services.AddScoped<IValidator<CreateBookingCommand>, CreateBookingCommandValidatior>();
        services.AddScoped<IValidator<PatchBookingCommand>, PatchBookingCommandValidatior>();

        return services;
    }
}