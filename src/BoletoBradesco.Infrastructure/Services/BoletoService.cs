using BoletoBradesco.Application.Interfaces;
using BoletoBradesco.Domain.Entities;
using BoletoNetCore;
using BoletoNetCore.Extensions;
using Microsoft.Extensions.Configuration;

namespace BoletoBradesco.Infrastructure;

public class BoletoService : IBoletoService
{

    private readonly IPdfService _pdfService;
    private readonly IConfiguration _configuration;

    public BoletoService(IPdfService pdfService, IConfiguration configuration)
    {
        _pdfService = pdfService;
        _configuration = configuration;
    }


    public string GerarBoletoHtml(BoletoBanco input)
    {
        var beneficiario = new Beneficiario
        {
            CPFCNPJ = _configuration["DadosCedente:CNPJ"],
            Nome = _configuration["DadosCedente:RazaoSocial"],
            CodigoTransmissao = "1234567",
            CodigoFormatado = _configuration["DadosCedente:Beneficiario"],
            ContaBancaria = new ContaBancaria
            {
                Agencia = _configuration["DadosCedente:Agencia"],
                DigitoAgencia = "0",
                Conta = _configuration["DadosCedente:ContaCorrente"].Left(7),
                DigitoConta = _configuration["DadosCedente:ContaCorrente"].Right(1),
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
                CEP = input.SacadoCEP
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
        };

        return boletoBancario.MontaHtmlEmbedded();
    }

    public byte[] GerarBoletoPdf(BoletoBanco input)
    {
        var html = GerarBoletoHtml(input);
        return _pdfService.GerarPdf(html);
    }

}