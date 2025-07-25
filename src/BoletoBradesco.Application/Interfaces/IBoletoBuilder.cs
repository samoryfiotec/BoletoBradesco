using BoletoBradesco.Domain.DTOs;
using BoletoNetCore;

namespace BoletoBradesco.Application.Interfaces
{
    public interface IBoletoBuilder
    {
        Boleto CriarBoleto(BoletoInputDto input);
    }
}
