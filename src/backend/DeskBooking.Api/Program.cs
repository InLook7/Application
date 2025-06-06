using Scalar.AspNetCore;
using DeskBooking.Api.Endpoints;
using DeskBooking.Api.Middleware;
using DeskBooking.Application.Extensions;
using DeskBooking.Infrastructure.Extensions;
using DeskBooking.Infrastructure.Persistence.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);

builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
		policy.WithOrigins("http://localhost:4200")
        	.AllowAnyHeader()
        	.AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapWorkspaceTypeEndpoints();
app.MapBookingEndpoints();

app.UseStaticFiles();

app.UseCors("CorsPolicy");

// Seeding
using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var context = services.GetRequiredService<ApplicationDbContext>();
	await ApplicationDbContextSeeder.SeedAsync(context);
}

app.Run();
