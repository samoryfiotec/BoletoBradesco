using BoletoBradesco.Application.Interfaces;
using BoletoBradesco.Domain.Entities;
using BoletoBradesco.Infrastructure;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;

namespace BoletoBradesco.Tests
{
    public class BoletoServiceTests
    {
        [Fact]
        public void GerarBoletoHtml_DeveRetornarHtmlValido()
        {
            // Arrange
            var mockPdfService = new Mock<IPdfService>();
            mockPdfService.Setup(p => p.GerarPdf(It.IsAny<string>())).Returns(new byte[0]);

            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(c => c["DadosCedente:RazaoSocial"]).Returns("Fiotec - Fundação de Apoio à Pesquisa e Inovação Tecnológica");
            mockConfiguration.Setup(c => c["DadosCedente:CNPJ"]).Returns("12345678000195");
            mockConfiguration.Setup(c => c["DadosCedente:Beneficiario"]).Returns("1234567");
            mockConfiguration.Setup(c => c["DadosCedente:Agencia"]).Returns("1234");
            mockConfiguration.Setup(c => c["DadosCedente:ContaCorrente"]).Returns("12345678");

            var service = new BoletoService(mockPdfService.Object, mockConfiguration.Object);

            var input = new BoletoBanco
            {
                CedenteNome = "Fiotec - Fundação de Apoio à Pesquisa e Inovação Tecnológica",
                CedenteCPFCNPJ = "12345678000195",
                SacadoNome = "Jose das Couves",
                SacadoDocumento = "12345678909",
                SacadoCEP = "20000000",
                NossoNumero = "31654",
                Valor = 1000,
                Vencimento = DateTime.Today.AddDays(5)
            };

            // Act
            var html = service.GerarBoletoHtml(input);

            // Assert
            html.Should().NotBeNullOrWhiteSpace();
            html.Should().Contain("Fiotec - Fundação de Apoio à Pesquisa e Inovação Tecnológica");
            html.Should().Contain("Jose das Couves");
            html.Should().Contain("31654");
        }


        [Fact]
        public void GerarBoletoPdf_DeveChamarPdfServiceComHtml()
        {
            // Arrange
            var mockPdfService = new Mock<IPdfService>();
            mockPdfService.Setup(p => p.GerarPdf(It.IsAny<string>())).Returns(System.Text.Encoding.UTF8.GetBytes("%PDF-1.4"));


            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(c => c["DadosCedente:RazaoSocial"]).Returns("Fiotec - Fundação de Apoio à Pesquisa e Inovação Tecnológica");
            mockConfiguration.Setup(c => c["DadosCedente:CNPJ"]).Returns("12345678000195");
            mockConfiguration.Setup(c => c["DadosCedente:Beneficiario"]).Returns("1234567");
            mockConfiguration.Setup(c => c["DadosCedente:Agencia"]).Returns("1234");
            mockConfiguration.Setup(c => c["DadosCedente:ContaCorrente"]).Returns("12345678"); // precisa ter pelo menos 8 caracteres

            var service = new BoletoService(mockPdfService.Object, mockConfiguration.Object);
            var input = new BoletoBanco
            {
                CedenteNome = "Empresa Exemplo LTDA",
                CedenteCPFCNPJ = "02175818705",
                SacadoNome = "Jose das Couves",
                SacadoDocumento = "02175818705",
                SacadoCEP = "20000000",
                NossoNumero = "31654",
                Valor = 1000,
                Vencimento = DateTime.Today.AddDays(5)
            };

            // Act
            var pdf = service.GerarBoletoPdf(input);

            // Assert
            pdf.Should().NotBeNull();
            pdf.Should().NotBeEmpty();
            pdf.Length.Should().BeGreaterThan(0);
        }
    }
}