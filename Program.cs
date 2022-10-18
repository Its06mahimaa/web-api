using Microsoft.EntityFrameworkCore;
using trainingproject.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Environment.ContentRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
builder.Services.AddDbContext<BooksContext>(opt =>
        opt.UseSqlServer(
           builder.Configuration.GetConnectionString("dbconn")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
