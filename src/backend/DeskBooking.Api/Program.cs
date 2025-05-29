using Scalar.AspNetCore;
using DeskBooking.Api.Endpoints;
using DeskBooking.Api.Middleware;
using DeskBooking.Application.Extensions;
using DeskBooking.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapWorkspaceTypeEndpoints();
app.MapBookingEndpoints();

app.Run();
