using BoletoBradesco.Application.Interfaces;
using iText.Html2pdf;
using iText.IO.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Font;

public class PdfService : IPdfService
{

    public byte[] GerarPdf(string html)
    {
        using var memoryStream = new MemoryStream();

        var writer = new PdfWriter(memoryStream);
        var pdfDocument = new PdfDocument(writer);

        // Define um tamanho personalizado: largura = 120pt, altura = 200pt
        PageSize customSize = new PageSize(1000, 842);
        
        pdfDocument.SetDefaultPageSize(customSize);


        var fontProvider = new FontProvider();
        fontProvider.AddFont("C:/Windows/Fonts/arial.ttf");       // Arial regular
        fontProvider.AddFont("C:/Windows/Fonts/arialbd.ttf");     // Arial bold
        fontProvider.AddFont("C:/Windows/Fonts/Arial Narrow Regular.ttf");      // Arial Narrow regular


        // Caminho da fonte personalizada
        //var fontPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Fonts", "tahoma.ttf");


        // Configurações do conversor
        var converterProperties = new ConverterProperties();
        converterProperties.SetFontProvider(fontProvider);
        converterProperties.SetCharset("utf-8");

        HtmlConverter.ConvertToPdf(html, pdfDocument, converterProperties);
        pdfDocument.Close();

        return memoryStream.ToArray();
    }
}
