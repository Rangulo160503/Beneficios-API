using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Flujo;
using Microsoft.Extensions.Configuration;
using Reglas;
using Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// REGISTRO DE FLUJOS
builder.Services.AddScoped<IBeneficioFlujo, BeneficiosFlujo>();

// REGISTRO DE SERVICIOS
builder.Services.AddScoped<IBeneficiosServicio, BeneficiosServicio>();

// REGISTRO DE CONFIGURACION PERSONALIZADA
builder.Services.AddScoped<IConfiguracion, Configuracion>();

// REGISTRO DE HTTPCLIENT FACTORY

builder.Services.AddHttpClient("ServicioBeneficio", client =>
{
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    // Puedes agregar BaseAddress o Headers aquí si quieres
});

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
