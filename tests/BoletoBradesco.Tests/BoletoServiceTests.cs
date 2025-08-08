using BoletoBradesco.Application.Interfaces;
using BoletoBradesco.Domain.DTOs;
using BoletoBradesco.Infrastructure;
using BoletoNetCore;
using FluentAssertions;
using Moq;

namespace BoletoBradesco.Tests
{
    public class BoletoServiceTests
    {
        //[Fact]
        //public void GerarBoletoHtml_DeveRetornarHtmlValido()
        //{
        //    // Arrange
        //    var mockPdfService = new Mock<IPdfService>();
        //    mockPdfService.Setup(p => p.GerarPdf(It.IsAny<string>())).Returns(new byte[0]);

        //    var mockBuilder = new Mock<IBoletoBuilder>();
        //    mockBuilder.Setup(b => b.CriarBoleto(It.IsAny<BoletoInputDto>()));
        //               //.Returns(new Boleto
        //               //{
        //               //    Pagador = new BoletoNetCore.Pagador { Nome = "Jose das Couves" },
        //               //    ValorTitulo = 1000,
        //               //    NossoNumero = "31654",
        //               //    Banco = BoletoNetCore.Banco.Instancia(BoletoNetCore.Bancos.Bradesco),
        //               //    Beneficiario = new BoletoNetCore.Beneficiario { Nome = "Fiotec - Fundação de Apoio à Pesquisa e Inovação Tecnológica" }
        //               //});

        //    var service = new BoletoService(mockBuilder.Object, mockPdfService.Object);

        //    var input = new BoletoInputDto
        //    {
        //        CedenteNome = "Fiotec - Fundação de Apoio à Pesquisa e Inovação Tecnológica",
        //        CedenteCPFCNPJ = "12345678000195",
        //        SacadoNome = "Jose das Couves",
        //        SacadoDocumento = "12345678909",
        //        SacadoCEP = "20000000",
        //        NossoNumero = "31654",
        //        Valor = 1000,
        //        Vencimento = DateTime.Today.AddDays(5)
        //    };

        //    // Act
        //    var html = service.GerarBoletoHtml(input);

        //    // Assert
        //    html.Should().NotBeNullOrWhiteSpace();
        //    html.Should().Contain("Fiotec - Fundação de Apoio à Pesquisa e Inovação Tecnológica");
        //    html.Should().Contain("Jose das Couves");
        //    html.Should().Contain("31654");
        //}

        //[Fact]
        //public void GerarBoletoPdf_DeveChamarPdfServiceComHtml()
        //{
        //    // Arrange
        //    var mockPdfService = new Mock<IPdfService>();
        //    mockPdfService.Setup(p => p.GerarPdf(It.IsAny<string>()))
        //                  .Returns(System.Text.Encoding.UTF8.GetBytes("%PDF-1.4"));

        //    var mockBuilder = new Mock<IBoletoBuilder>();
        //    mockBuilder.Setup(b => b.CriarBoleto(It.IsAny<BoletoInputDto>()));
        //               //.Returns(new Boleto
        //               //{
        //               //    Pagador = new BoletoNetCore.Pagador { Nome = "Jose das Couves" },
        //               //    ValorTitulo = 1000,
        //               //    NossoNumero = "31654",
        //               //    Banco = BoletoNetCore.Banco.Instancia(BoletoNetCore.Bancos.Bradesco),
        //               //    Cedente = new BoletoNetCore.Cedente { Nome = "Empresa Exemplo LTDA" }
        //               //});

        //    var service = new BoletoService(mockBuilder.Object, mockPdfService.Object);

        //    var input = new BoletoInputDto
        //    {
        //        CedenteNome = "Empresa Exemplo LTDA",
        //        CedenteCPFCNPJ = "02175818705",
        //        SacadoNome = "Jose das Couves",
        //        SacadoDocumento = "02175818705",
        //        SacadoCEP = "20000000",
        //        NossoNumero = "31654",
        //        Valor = 1000,
        //        Vencimento = DateTime.Today.AddDays(5)
        //    };

        //    // Act
        //    var pdf = service.GerarBoletoPdf(input);

        //    // Assert
        //    pdf.Should().NotBeNull();
        //    pdf.Should().NotBeEmpty();
        //    pdf.Length.Should().BeGreaterThan(0);
        //}
    }
}