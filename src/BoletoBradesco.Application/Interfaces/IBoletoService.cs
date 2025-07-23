using BoletoBradesco.Domain.Entities;

namespace BoletoBradesco.Application.Interfaces
{
    public interface IBoletoService
    {
        byte[] GerarBoletoPdf(BoletoBanco input);

        string GerarBoletoHtml(BoletoBanco input);
    }

}
