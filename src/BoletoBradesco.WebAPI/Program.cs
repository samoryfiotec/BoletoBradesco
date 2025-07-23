using BoletoBradesco.Application.Interfaces;
using BoletoBradesco.Domain.Entities;
using BoletoBradesco.Infrastructure;
using BoletoBradesco.Infrastructure.Services;
using DinkToPdf.Contracts;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IBoletoService, BoletoService>();
builder.Services.AddSingleton<IConverter>(PdfConverter.Create());
builder.Services.AddScoped<PdfService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "openapi/v1.json";
    });
}

app.MapPost("/api/boletos/html", (BoletoBanco boleto, IBoletoService boletoService) =>
{
    var html = boletoService.GerarBoletoHtml(boleto);
    return Results.Content(html, "text/html");
})
 .WithName("GerarHtml");

app.MapPost("/api/boletos/pdf", (BoletoBanco boleto, IBoletoService boletoService) =>
{
    var pdf = boletoService.GerarBoletoPdf(boleto);
    return Results.File(pdf, "application/pdf", "boleto.pdf");
})
.WithName("GerarBoleto")
.WithOpenApi();

app.Run();