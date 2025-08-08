using BoletoBradesco.Application;
using BoletoBradesco.Application.Interfaces;
using BoletoBradesco.Domain.DTOs;
using BoletoBradesco.Infrastructure;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IBoletoBuilder, BoletoBuilder>();
builder.Services.AddScoped<IBoletoService, BoletoService>();
builder.Services.AddScoped<IPdfService, PdfService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "openapi/v1.json";
    });
}

app.MapPost("/api/boletos/html", (BoletoInputDto boleto, IBoletoService boletoService) =>
{
    var html = boletoService.GerarBoletoHtml(boleto);
    return Results.Content(html, "text/html");
})
 .WithName("GerarHtml");

app.MapPost("/api/boletos/pdf", (BoletoInputDto boleto, IBoletoService boletoService) =>
{
    var pdf = boletoService.GerarBoletoPdf(boleto);
    return Results.File(pdf, "application/pdf", "boleto.pdf");
})
.WithName("GerarBoleto")
.WithOpenApi();

app.Run();