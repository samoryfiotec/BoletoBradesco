using DinkToPdf;
using DinkToPdf.Contracts;

namespace BoletoBradesco.Infrastructure.Services
{
    public static class PdfConverter
    {
        public static IConverter Create()
        {
            return new SynchronizedConverter(new PdfTools());
        }
    }

}
