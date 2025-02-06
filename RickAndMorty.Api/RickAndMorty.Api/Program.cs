
using RickAndMorty.Api.Configurations;
using RickAndMorty.Application.UseCases;
using RickAndMorty.Domain.Repositories;
using RickAndMorty.Infrastructure.Persistence;
using RickAndMorty.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Configura CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("ApiSettings"));

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

// Usa CORS antes de otros middlewares
app.UseCors("AllowSpecificOrigins");

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
