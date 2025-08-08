
using System.Net;
using System.Net.Http.Json;
using BoletoBradesco.Domain.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace BoletoBradesco.Tests.Integration
{
    public class BoletoApiIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public BoletoApiIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        //[Fact]
        //public async Task PostHtmlEndpoint_DeveRetornarHtmlDoBoleto()
        //{
        //    var client = _factory.CreateClient();

        //    var dto = new BoletoInputDto
        //    {
        //        CedenteNome = "Fiotec - Fundação de Apoio à Pesquisa e Inovação Tecnológica",
        //        CedenteCPFCNPJ = "12345678000195",
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

        //    var response = await client.PostAsJsonAsync("/api/boletos/html", dto);

        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //    var html = await response.Content.ReadAsStringAsync();
        //    Assert.Contains("Jose das Couves", html);
        //    Assert.Contains("31654", html);
        //}

        //[Fact]
        //public async Task PostPdfEndpoint_DeveRetornarPdfDoBoleto()
        //{
        //    var client = _factory.CreateClient();

        //    var dto = new BoletoInputDto
        //    {
        //        CedenteNome = "Empresa Exemplo LTDA",
        //        CedenteCPFCNPJ = "02175818705",
        //        SacadoNome = "Jose das Couves",
        //        SacadoDocumento = "02175818705",
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

        //    var response = await client.PostAsJsonAsync("/api/boletos/pdf", dto);

        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //    var contentType = response.Content.Headers.ContentType?.MediaType;
        //    Assert.Equal("application/pdf", contentType);
        //    var pdfBytes = await response.Content.ReadAsByteArrayAsync();
        //    Assert.NotEmpty(pdfBytes);
        //}
    }
}
