using Desafio.Context;
using Desafio.Repository;
using Desafio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IAnuncioRepository, AnuncioRepository>();

string mySqlConnection =
              builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContextPool<AnuncioContext>(options =>
                options.UseMySql(mySqlConnection,
                      ServerVersion.AutoDetect(mySqlConnection)));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
