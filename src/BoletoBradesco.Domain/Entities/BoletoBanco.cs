namespace BoletoBradesco.Domain.Entities
{

    public class BoletoBanco
    {
        public BoletoBanco() { }

        public string CedenteNome { get; set; } = string.Empty;
        public string CedenteCPFCNPJ { get; set; } = string.Empty;
        public string SacadoNome { get; set; } = string.Empty;
        public string SacadoDocumento { get; set; } = string.Empty;
        public string SacadoLogradouro {  get; set; } = string.Empty;
        public string SacadoNumero { get; set; } = string.Empty;
        public string SacadoBairro {  get; set; } = string.Empty;
        public string SacadoCidade {  get; set; } = string.Empty;    
        public string SacadoUF {  get; set; } = string.Empty;
        public string SacadoCEP { get; set; } = string.Empty;
        public string NossoNumero { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime Vencimento { get; set; }
    }

}
