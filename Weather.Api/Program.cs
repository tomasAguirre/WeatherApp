using Weather.Application;
using WeatherApp.Domain;
using WeatherApp.WeatherbitAPI;
using WeatherApp.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddPersistenceServicesRegistry();
builder.Services.addApplicationServicesWeatherbitApi();
builder.Services.addApplicationServicesApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
