using BoletoBradesco.Domain.DTOs;

namespace BoletoBradesco.Application.Interfaces
{
    public interface IBoletoService
    {
        byte[] GerarBoletoPdf(BoletoInputDto input);

        string GerarBoletoHtml(BoletoInputDto input);
    }

}
