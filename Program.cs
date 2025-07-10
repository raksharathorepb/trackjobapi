using Microsoft.EntityFrameworkCore;
using TrackJobAPI.Data;
using TrackJobAPI.Interfaces;
using TrackJobAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// SQLite 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=jobs.db"));

// DI (Dependency Injction)
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();

// Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

//Swagger for API documentation
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TrackJobAPI v1");
    c.RoutePrefix = string.Empty; //it make Swagger on UI default at "/"
});

//Enable CORS
app.UseCors("AllowReact");

app.UseAuthorization();
app.MapControllers();
app.Run();
