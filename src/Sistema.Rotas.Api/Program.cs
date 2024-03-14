using Sistema.Rotas.Data.Baseteste;
using Sistema.Rotas.Data.Repositories.Rotaroot;
using Sistema.Rotas.Domain.RotasRoot.Commands.Handlers;
using Sistema.Rotas.Domain.RotasRoot.Interfaces;
using Sistema.Rotas.Domain.RotasRoot.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRotaReadRepository, RotaReadRepository>();
builder.Services.AddScoped<IRotaRepository, RotaRepository>();
builder.Services.AddScoped<IRotaService, RotaService>();
builder.Services.AddScoped<IRotaHandler, RotaHandler>();

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
