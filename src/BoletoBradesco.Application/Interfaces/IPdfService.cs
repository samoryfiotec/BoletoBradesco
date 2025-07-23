namespace BoletoBradesco.Application.Interfaces
{
    public interface IPdfService
    {
        byte[] GerarPdf(string html);
    }

}
