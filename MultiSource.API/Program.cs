using MultiSource.API.Middlewares;
using MultiSource.API.Services;
using MultiSource.Domain.Repositories;
using MultiSource.Domain.Services;
using MultiSource.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITourService, TourService>();
builder.Services.AddSingleton<ITourRepository, SomeOtherGuyRepository>();
builder.Services.AddSingleton<ITourRepository, TheBigGuyRepository>();
builder.Services.AddSingleton<ITourRepository, TheTourGuyRepository>();

builder.Services.AddScoped<ErrorHandlerMiddleware>();

builder.Services
    .AddControllers()
    .AddJsonOptions(o =>
        {
            o.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
