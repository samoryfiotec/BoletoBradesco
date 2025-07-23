using BoletoBradesco.Domain.Entities;
using BoletoBradesco.Infrastructure;
using BoletoNetCore;
using FluentAssertions;

namespace BoletoBradesco.Tests
{
    public class BoletoServiceTests
    {
        //[Fact]
        //public void Deve_Gerar_PDF_Com_Boleto_Valido()
        //{
        //    var service = new BoletoService();
        //    var boleto = new BoletoBanco
        //    {
        //        CedenteNome = "Empresa XYZ",
        //        CedenteCPFCNPJ = "12345678000199",
        //        SacadoNome = "Cliente ABC",
        //        SacadoDocumento = "98765432100",
        //        NossoNumero = "12345678",
        //        Valor = 150.75m,
        //        Vencimento = DateTime.Today.AddDays(5)
        //    };

        //    var pdf = service.GerarBoletoPdf(boleto);

        //    pdf.Should().NotBeNull();
        //    pdf.Length.Should().BeGreaterThan(1000);
        //}
    }

}
