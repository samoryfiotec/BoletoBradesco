using BoletoBradesco.Application.Interfaces;
using BoletoBradesco.Domain.Entities;
using BoletoBradesco.Infrastructure;
using BoletoBradesco.Infrastructure.Services;
using DinkToPdf.Contracts;
using FluentAssertions;
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
            var service = new BoletoService(mockPdfService.Object);
            var input = new BoletoBanco
            {
                CedenteNome = "Empresa Exemplo LTDA",
                CedenteCPFCNPJ = "12345678000195",
                SacadoNome = "Jose das Couves",
                SacadoDocumento = "12345678909",
                NossoNumero = "31654",
                Valor = 1000,
                Vencimento = DateTime.Today.AddDays(5)
            };

            // Act
            var html = service.GerarBoletoHtml(input);

            // Assert
            html.Should().NotBeNullOrWhiteSpace();
            html.Should().Contain("Empresa Exemplo LTDA");
            html.Should().Contain("Jose das Couves");
            html.Should().Contain("31654");
        }

        [Fact]
        public void GerarBoletoPdf_DeveChamarPdfServiceComHtml()
        {
            // Arrange
            var mockPdfService = new Mock<IPdfService>();
            mockPdfService.Setup(p => p.GerarPdf(It.IsAny<string>())).Returns(new byte[0]);
            var service = new BoletoService(mockPdfService.Object);
            var input = new BoletoBanco
            {
                CedenteNome = "Empresa Exemplo LTDA",
                CedenteCPFCNPJ = "02175818705",
                SacadoNome = "Jose das Couves",
                SacadoDocumento = "02175818705",
                NossoNumero = "31654",
                Valor = 1000,
                Vencimento = DateTime.Today.AddDays(5)
            };

            // Act
            var pdf = service.GerarBoletoPdf(input);            

            // Assert
            pdf.Should().NotBeNull();            
        }
    }
}