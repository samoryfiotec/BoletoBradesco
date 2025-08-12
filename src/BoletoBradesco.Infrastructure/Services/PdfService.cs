using BoletoBradesco.Application.Interfaces;
using iText.Html2pdf;
using iText.Html2pdf.Css.Apply.Impl;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Font;

public class PdfService : IPdfService
{

    public byte[] GerarPdf(string html)
    {
        using var memoryStream = new MemoryStream();

        var writer = new PdfWriter(memoryStream);
        var pdfDocument = new PdfDocument(writer);

        //PageSize customSize = new PageSize(700, 842);
        pdfDocument.SetDefaultPageSize(PageSize.A4);

        var fontProvider = new FontProvider();
        fontProvider.AddFont("C:/Windows/Fonts/arial.ttf");
        fontProvider.AddFont("C:/Windows/Fonts/arialbd.ttf");
        fontProvider.AddFont("C:/Windows/Fonts/Arial Narrow Regular.ttf");

        var converterProperties = new ConverterProperties();
        converterProperties.SetFontProvider(fontProvider);
        converterProperties.SetCharset("utf-8");
        converterProperties.SetCssApplierFactory(new DefaultCssApplierFactory());


        // Cria o Document com margens zeradas
        var document = new Document(pdfDocument);
        document.SetMargins(5, 5, 5, 5); // top, right, bottom, left

        // Converte HTML em elementos
        var elements = HtmlConverter.ConvertToElements(html, converterProperties);

        // Adiciona os elementos ao documento
        foreach (var element in elements)
        {
            document.Add((iText.Layout.Element.IBlockElement)element);
        }

        document.Close();
        return memoryStream.ToArray();
    }

}
