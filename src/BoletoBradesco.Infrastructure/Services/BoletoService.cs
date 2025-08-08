using BoletoBradesco.Application.Interfaces;
using BoletoBradesco.Domain.DTOs;
using BoletoNetCore;

namespace BoletoBradesco.Infrastructure;

public class BoletoService : IBoletoService
{
    private readonly IBoletoBuilder _boletoBuilder;
    private readonly IPdfService _pdfService;

    public BoletoService(IBoletoBuilder boletoBuilder, IPdfService pdfService)
    {
        _boletoBuilder = boletoBuilder;
        _pdfService = pdfService;
    }

    public string GerarBoletoHtml(BoletoInputDto input)
    {
        var boleto = _boletoBuilder.CriarBoleto(input);
        var boletoBancario = new BoletoBancario
        {
            Boleto = boleto,
            OcultarInstrucoes = false
        };

        return boletoBancario.MontaHtmlEmbedded();
    }

    public byte[] GerarBoletoPdf(BoletoInputDto input)
    {
        var html = GerarBoletoHtml(input);
        return _pdfService.GerarPdf(html);
    }
}