using Weather.Application;
using WeatherApp.Domain;
using WeatherApp.WeatherbitAPI;
using WeatherApp.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMemoryCache();

builder.Services.AddPersistenceServicesRegistry();
builder.Services.addApplicationServicesWeatherbitApi();
builder.Services.addApplicationServicesApplication();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowFrontend", policy =>
        {
            policy.WithOrigins("https://localhost:7245") 
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.


if (!builder.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

if (builder.Environment.IsDevelopment())
{
    app.UseCors("AllowFrontend");

    app.MapGet("/", context =>
    {
        context.Response.Redirect("/index.html");
        return Task.CompletedTask;
    });
}
   
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
