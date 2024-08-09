using Ebookapp.API.Context;
using Ebookapp.API.Interfaces;
using Ebookapp.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager configurationManager = builder.Configuration;
var connectionString = configurationManager.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddDbContext<EBookContextDB>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IBookServices, BookService>();


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
