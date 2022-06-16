using Microsoft.EntityFrameworkCore;
using csharp_blog_backend.Models;

var builder = WebApplication.CreateBuilder(args);
// MODIFICA AGGIUNTA
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("https://localhost:3000").AllowAnyHeader().AllowAnyMethod();
        });
});
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<BlogContext>(opt =>
    opt.UseInMemoryDatabase("posts"));




var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
