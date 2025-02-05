using Microsoft.EntityFrameworkCore;
using RickAndMorty.Application.UseCases;
using RickAndMorty.Domain.Repositories;
using RickAndMorty.Infrastructure.Persistence;
using RickAndMorty.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Inyección de dependencias
builder.Services.AddHttpClient(); // Para HttpClient
builder.Services.AddScoped<RickAndMortyApiService>();
builder.Services.AddScoped<IEpisodioRepository, EpisodioRepository>();
builder.Services.AddScoped<ObtenerEpisodiosUseCase>();

// Add services to the container.

builder.Services.AddControllers();
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
