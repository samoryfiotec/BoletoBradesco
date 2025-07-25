using BoletoBradesco.Application.Interfaces;
using BoletoBradesco.Domain.DTOs;
using BoletoNetCore;
using Microsoft.Extensions.Configuration;

namespace BoletoBradesco.Application
{
    public class BoletoBuilder : IBoletoBuilder
    {
        private readonly IConfiguration _configuration;

        public BoletoBuilder(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Boleto CriarBoleto(BoletoInputDto input)
        {
            var beneficiario = new Beneficiario
            {
                CPFCNPJ = _configuration["DadosCedente:CNPJ"],
                Nome = _configuration["DadosCedente:RazaoSocial"],
                CodigoTransmissao = "2601841165",
                CodigoFormatado = _configuration["DadosCedente:Beneficiario"],
                ContaBancaria = new ContaBancaria
                {
                    Agencia = _configuration["DadosCedente:Agencia"],
                    DigitoAgencia = "0",
                    Conta = _configuration["DadosCedente:ContaCorrente"],
                    DigitoConta = _configuration["DadosCedente:DigitoCC"],
                    CarteiraPadrao = "09",
                    TipoCarteiraPadrao = TipoCarteira.CarteiraCobrancaSimples,
                    TipoFormaCadastramento = TipoFormaCadastramento.ComRegistro,
                    TipoImpressaoBoleto = TipoImpressaoBoleto.Empresa
                }
            };

            var pagador = new Pagador
            {
                CPFCNPJ = input.SacadoDocumento,
                Nome = input.SacadoNome,
                Endereco = new Endereco
                {
                    LogradouroEndereco = input.SacadoLogradouro,
                    LogradouroNumero = input.SacadoNumero,
                    Bairro = input.SacadoBairro,
                    Cidade = input.SacadoCidade,
                    UF = input.SacadoUF,
                    CEP = input.SacadoCEP
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
                EspecieDocumento = TipoEspecieDocumento.DM,
                DataEmissao = DateTime.Now,
                DataProcessamento = DateTime.Now,
                DataVencimento = input.Vencimento,
                ImprimirMensagemInstrucao = true,
                MensagemInstrucoesCaixa = _configuration["DadosCedente:Instrucoes"]
            };

            boleto.ValidarDados();
            return boleto;
        }
    }
}
