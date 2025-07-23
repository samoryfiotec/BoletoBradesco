using BoletoBradesco.Application.Interfaces;
using BoletoBradesco.Domain.Entities;
using BoletoBradesco.Infrastructure.Services;
using BoletoNetCore;

namespace BoletoBradesco.Infrastructure;

public class BoletoService : IBoletoService
{

    private readonly PdfService _pdfService;

    public BoletoService(PdfService pdfService)
    {
        _pdfService = pdfService;
    }

    public string GerarBoletoHtml(BoletoBanco input)
    {
        var beneficiario = new Beneficiario
        {
            CPFCNPJ = input.CedenteCPFCNPJ,
            Nome = input.CedenteNome,
            CodigoTransmissao = "1234567",
            ContaBancaria = new ContaBancaria
            {
                Agencia = "1234",
                DigitoAgencia = "0",
                Conta = "1234856",
                DigitoConta = "7",
                CarteiraPadrao = "09",
                TipoCarteiraPadrao = TipoCarteira.CarteiraCobrancaSimples
            }
        };

        var pagador = new Pagador
        {
            CPFCNPJ = input.SacadoDocumento,
            Nome = input.SacadoNome,
            Endereco = new Endereco
            {
                LogradouroEndereco = "Rua Exemplo",
                LogradouroNumero = "123",
                Bairro = "Centro",
                Cidade = "Rio de Janeiro",
                UF = "RJ",
                CEP = "20000-000"
            }
        };

        var banco = Banco.Instancia(Bancos.Bradesco);
        banco.Beneficiario = beneficiario;

        var boleto = new Boleto(banco)
        {
            Pagador = pagador,
            ValorTitulo = input.Valor,
            NossoNumero = input.NossoNumero,
            NumeroDocumento = input.NossoNumero,
            EspecieDocumento = TipoEspecieDocumento.DS,
            DataEmissao = DateTime.Now,
            DataProcessamento = DateTime.Now,
            DataVencimento = input.Vencimento
        };

        boleto.ValidarDados();

        var boletoBancario = new BoletoBancario
        {
            Boleto = boleto,
            OcultarInstrucoes = false
            //OcultarReciboSacado = false
        };

        return boletoBancario.MontaHtmlEmbedded();
    }

    public byte[] GerarBoletoPdf(BoletoBanco input)
    {
        var html = GerarBoletoHtml(input); // usa BoletoNetCore
        return _pdfService.GerarPdf(html); // usa DinkToPdf
    }
    
}