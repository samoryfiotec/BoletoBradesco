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


    //public byte[] GerarBoletoPdf(BoletoBanco input)
    //{

    //    QuestPDF.Settings.License = LicenseType.Community;


    //    var beneficiario = new Beneficiario
    //    {
    //        CPFCNPJ = "12345678000195", // CNPJ válido com 14 dígitos
    //        Nome = "Empresa Exemplo LTDA",
    //        CodigoTransmissao = "1234567", // Código fornecido pelo banco (7 dígitos)
    //        ContaBancaria = new ContaBancaria
    //        {
    //            Agencia = "1234", // 4 dígitos
    //            DigitoAgencia = "0", // 1 dígito
    //            Conta = "1234586", // 6 dígitos
    //            DigitoConta = "7", // 1 dígito
    //            CarteiraPadrao = "09", // Carteira padrão do Bradesco
    //            VariacaoCarteiraPadrao = "", // Pode ficar vazio
    //            TipoCarteiraPadrao = TipoCarteira.CarteiraCobrancaSimples
    //        }
    //    };

    //    var pagador = new Pagador
    //    {
    //        CPFCNPJ = "12345678909",//input.SacadoDocumento,
    //        Nome = input.SacadoNome,
    //        Endereco = new Endereco
    //        {
    //            LogradouroEndereco = "Rua Exemplo",
    //            LogradouroNumero = "123",
    //            Bairro = "Centro",
    //            Cidade = "Rio de Janeiro",
    //            UF = "RJ",
    //            CEP = "20000-000"
    //        }
    //    };

    //    var banco = Banco.Instancia(Bancos.Bradesco);
    //    banco.Beneficiario = beneficiario;

    //    var boleto = new Boleto(banco)
    //    {
    //        Pagador = pagador,
    //        ValorTitulo = input.Valor,
    //        NossoNumero = input.NossoNumero,
    //        NumeroDocumento = input.NossoNumero,
    //        EspecieDocumento = TipoEspecieDocumento.DS,
    //        DataEmissao = DateTime.Now,
    //        DataProcessamento = DateTime.Now,
    //        DataVencimento = input.Vencimento
    //    };

    //    boleto.ValidarDados();

    //    var barcodeWriter = new BarcodeWriterPixelData
    //    {
    //        Format = BarcodeFormat.CODE_128,
    //        Options = new EncodingOptions
    //        {
    //            Height = 60,
    //            Width = 400,
    //            Margin = 10
    //        }
    //    };


    //    if (string.IsNullOrWhiteSpace(boleto.CodigoBarra?.CodigoDeBarras))
    //        throw new ArgumentException("Linha digitável do código de barras está vazia.");

    //    var barcodeBytes = RenderBarcodeToPng(barcodeWriter, boleto.CodigoBarra.CodigoDeBarras);

    //    var pdf = Document.Create(container =>
    //    {
    //        container.Page(page =>
    //        {
    //            page.Margin(30);
    //            page.Size(PageSizes.A4);
    //            page.Content().Column(col =>
    //            {
    //                col.Item().Text($"Boleto Bradesco - {input.CedenteNome}").FontSize(18).Bold();
    //                col.Item().Text($"Sacado: {input.SacadoNome} - CPF/CNPJ: {input.SacadoDocumento}");
    //                col.Item().Text($"Valor: R$ {input.Valor:F2} - Vencimento: {input.Vencimento:dd/MM/yyyy}");
    //                col.Item().Text($"Nosso Número: {input.NossoNumero}");
    //                col.Item().Image(barcodeBytes);
    //            });
    //        });
    //    }).GeneratePdf();

    //    return pdf;
    //}

    //private byte[] RenderBarcodeToPng(BarcodeWriterPixelData writer, string content)
    //{
    //    var pixelData = writer.Write(content);

    //    using var bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb);
    //    var bitmapData = bitmap.LockBits(
    //        new Rectangle(0, 0, pixelData.Width, pixelData.Height),
    //        ImageLockMode.WriteOnly,
    //        PixelFormat.Format32bppRgb);

    //    System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
    //    bitmap.UnlockBits(bitmapData);

    //    using var stream = new MemoryStream();
    //    bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
    //    return stream.ToArray();
    //}
}