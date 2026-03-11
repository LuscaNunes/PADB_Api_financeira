using System.ComponentModel.DataAnnotations;

namespace ApiFinanceiro.Dtos
{
    public class DespesaDto
    {
        [Required(ErrorMessage = "Descrição Obrigatoria")]
        [MinLength(5, ErrorMessage = "Obrigatorio Mínimo de 5 caracteres")]
        public required string Descricao { get; set; }
        [Required(ErrorMessage = "O campo Categoria é obrigatorio")]
        public required string Categoria { get; set; }
        [Required(ErrorMessage = "O campo Valor é obrigatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
        public required decimal Valor { get; set; }
        [Required(ErrorMessage = "O campo Data de Vencimento é obrigatorio")]
        
        public required DateOnly DataVencimento { get; set; }
    }
}
