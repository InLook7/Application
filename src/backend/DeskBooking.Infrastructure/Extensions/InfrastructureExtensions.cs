using DeskBooking.Domain.Interfaces;
using DeskBooking.Infrastructure.Persistence;
using DeskBooking.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

        return services;
    }
}