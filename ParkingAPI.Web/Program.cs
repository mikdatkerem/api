using ParkingAPI.Infrastructure;
using Microsoft.OpenApi;
using ParkingAPI.Application.Parkings.Commands.CreateParking;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// --------------------
// Services
// --------------------

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateParkingCommand).Assembly));

// Infrastructure
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// --------------------
// Pipeline
// --------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
