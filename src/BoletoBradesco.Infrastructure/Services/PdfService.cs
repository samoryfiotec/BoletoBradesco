using BoletoBradesco.Application.Interfaces;
using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Font;
using Path = System.IO.Path;

public class PdfService : IPdfService
{
    public byte[] GerarPdf(string html)
    {
        using var memoryStream = new MemoryStream();

        var writer = new PdfWriter(memoryStream);
        var pdfDocument = new PdfDocument(writer);
        pdfDocument.SetDefaultPageSize(PageSize.LETTER);

        var fontProvider = new FontProvider();

        string basePath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Fonts");
        fontProvider.AddFont(Path.Combine(basePath, "arial.ttf"));
        fontProvider.AddFont(Path.Combine(basePath, "arialbd.ttf"));
        fontProvider.AddFont(Path.Combine(basePath, "Arial Narrow Regular.ttf"));

        var converterProperties = new ConverterProperties();
        converterProperties.SetFontProvider(fontProvider);
        converterProperties.SetCharset("utf-8");

        string htmlTratado = AplicarNoWrapEmNumerosLongos(html);
        //HtmlConverter.ConvertToPdf(htmlTratado, pdfDocument, converterProperties);

        // Cria o Document com margens zeradas
        var document = new Document(pdfDocument);
        document.SetMargins(5, 5, 5, 5); // top, right, bottom, left       
                                         //document.GetTextRenderingMode();

        // Converte HTML em elementos
        var elements = HtmlConverter.ConvertToElements(htmlTratado, converterProperties);

        // Adiciona os elementos ao documento
        foreach (var element in elements)
        {
            document.Add((iText.Layout.Element.IBlockElement)element);
        }

        document.Close();
        return memoryStream.ToArray();


        //// Converte diretamente o HTML para PDF respeitando o CSS inline
        ////HtmlConverter.ConvertToPdf(htmlTratado, pdfDocument, converterProperties);

        //return memoryStream.ToArray();
    }

    public static string AplicarNoWrapEmNumerosLongos(string html)
    {
        // Regex para encontrar sequências numéricas longas (ex: 15+ dígitos ou números com muitos pontos)
        var regex = new System.Text.RegularExpressions.Regex(@"\b[\d\.]{15,}\b");

        // Substitui cada ocorrência por um span com estilo nowrap
        string resultado = regex.Replace(html, match =>
        {
            return $"<span style='white-space: nowrap;'>{match.Value}</span>";
        });

        return resultado;
    }


    //public byte[] GerarPdf(string html)
    //{
    //    using var memoryStream = new MemoryStream();

    //    var writer = new PdfWriter(memoryStream);
    //    var pdfDocument = new PdfDocument(writer);

    //    //PageSize customSize = new PageSize(700, 842);
    //    pdfDocument.SetDefaultPageSize(PageSize.A4);

    //    var fontProvider = new FontProvider();

    //    // Caminho base do projeto
    //    string basePath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Fonts");

    //    // Adiciona as fontes usando caminhos relativos
    //    fontProvider.AddFont(Path.Combine(basePath, "arial.ttf"));
    //    fontProvider.AddFont(Path.Combine(basePath, "arialbd.ttf"));
    //    fontProvider.AddFont(Path.Combine(basePath, "Arial Narrow Regular.ttf"));


    //    var converterProperties = new ConverterProperties();
    //    converterProperties.SetFontProvider(fontProvider);
    //    converterProperties.SetCharset("utf-8");
    //    converterProperties.SetCssApplierFactory(new DefaultCssApplierFactory());


    //    // Cria o Document com margens zeradas
    //    var document = new Document(pdfDocument);
    //    document.SetMargins(5, 5, 5, 5); // top, right, bottom, left       
    //    //document.GetTextRenderingMode();

    //    // Converte HTML em elementos
    //    var elements = HtmlConverter.ConvertToElements(html, converterProperties);

    //    // Adiciona os elementos ao documento
    //    foreach (var element in elements)
    //    {
    //        document.Add((iText.Layout.Element.IBlockElement)element);
    //    }

    //    document.Close();
    //    return memoryStream.ToArray();
    //}

}
