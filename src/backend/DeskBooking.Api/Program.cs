using DeskBooking.Api.Endpoints;
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
}

app.MapWorkspaceTypeEndpoints();
app.MapBookingEndpoints();

app.Run();
