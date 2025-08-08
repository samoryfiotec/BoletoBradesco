using BoletoBradesco.Application;
using BoletoBradesco.Domain.DTOs;
using BoletoNetCore;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;

namespace BoletoBradesco.Tests
{
    public class BoletoBuilderTests
    {
        private readonly IConfiguration _configuration;

        //[Fact]
        //public void CriarBoleto_DeveRetornarBoletoValidoComDadosCorretos()
        //{
        //    // Arrange
        //    var input = new BoletoInputDto
        //    {
        //        SacadoNome = "Jose das Couves",
        //        SacadoDocumento = "12345678909",
        //        SacadoLogradouro = "Rua do Cliente",
        //        SacadoNumero = "100",
        //        SacadoBairro = "Centro",
        //        SacadoCidade = "Rio de Janeiro",
        //        SacadoUF = "RJ",
        //        SacadoCEP = "20000000",
        //        NossoNumero = "31654",
        //        Valor = 1000,
        //        Vencimento = DateTime.Today.AddDays(5)
        //    };

        //    var cedenteOptions = new Beneficiario
        //    {
        //        CPFCNPJ = _configuration["DadosCedente:CNPJ"],
        //        Nome = _configuration["DadosCedente:RazaoSocial"],
        //        CodigoTransmissao = "2601841165",
        //        CodigoFormatado = _configuration["DadosCedente:Beneficiario"]/*,*/
        //        //ContaBancaria = new ContaBancaria
        //        //{
        //        //    Agencia = _configuration["DadosCedente:Agencia"],
        //        //    DigitoAgencia = "0",
        //        //    Conta = _configuration["DadosCedente:ContaCorrente"],
        //        //    DigitoConta = _configuration["DadosCedente:DigitoCC"],
        //        //    CarteiraPadrao = "09",
        //        //    //TipoCarteiraPadrao = TipoCarteira.CarteiraCobrancaSimples,
        //        //    //TipoFormaCadastramento = TipoFormaCadastramento.ComRegistro,
        //        //    //TipoImpressaoBoleto = TipoImpressaoBoleto.Empresa
        //        //}
        //    };

        //    var mockOptions = new Mock<IOptions<Beneficiario>>();
        //    mockOptions.Setup(o => o.Value).Returns(cedenteOptions);

        //    var builder = new BoletoBuilder(_configuration);

        //    // Act
        //    var boleto = builder.CriarBoleto(input);

        //    // Assert
        //    boleto.Should().NotBeNull();
        //    //boleto.Pagador.Nome.Should().Be("Jose das Couves");
        //    //boleto.Banco.Codigo.Should().Be(237); // Bradesco
        //    //boleto.ValorTitulo.Should().Be(1000);
        //    //boleto.NossoNumero.Should().Be("31654");
        //    //boleto.DataVencimento.Date.Should().Be(input.Vencimento.Date);
        //    //boleto.EspecieDocumento.Should().Be(TipoEspecieDocumento.DM);
        //}
    }
}
