using Microsoft.EntityFrameworkCore;
using WorkoutApp.Data;

// Prepares application 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{   // Map endpoints to OpenAPI standard
    app.MapOpenApi();
}


// Map HTTP requets to HTTPS
// app.UseHttpsRedirection();

app.MapControllers();

app.Run();

