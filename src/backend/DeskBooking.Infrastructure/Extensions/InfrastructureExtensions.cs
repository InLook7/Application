using System.ClientModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.AI;
using OpenAI;
using DeskBooking.Infrastructure.Persistence;
using DeskBooking.Infrastructure.Persistence.Data;
using DeskBooking.Infrastructure.Services;
using DeskBooking.Application.Common.Interfaces;
using DeskBooking.Domain.Interfaces;

namespace DeskBooking.Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructureLayer(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DeskBookingDatabase")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IBookingAssistant, BookingAssistant>();

        services.AddChatClient(provider =>
        {
            return new OpenAIClient(
                new ApiKeyCredential(configuration["GROQ_API_KEY"]),
                new OpenAIClientOptions()
                {
                    Endpoint = new Uri(configuration["GROQ_API_URL"])
                }).AsChatClient(configuration["GROQ_MODEL"]);
        });

        return services;
    }
}