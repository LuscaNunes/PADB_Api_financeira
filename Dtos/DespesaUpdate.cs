using System.ComponentModel.DataAnnotations;

namespace ApiFinanceiro.Dtos
{
    public class DespesaUpdate : DespesaDto
    {
        [Required]
        public required string Situacao { get; set; }
        [Required]
        public DateTime DataPagamento { get; set; }
    }
}
