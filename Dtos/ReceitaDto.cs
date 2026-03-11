using System.ComponentModel.DataAnnotations;

namespace ApiFinanceiro.Dtos
{
    public class ReceitaDto
    {
        [Required(ErrorMessage = "Descrição Obrigatória")]
        [MinLength(5, ErrorMessage = "Obrigatório Mínimo de 5 caracteres")]
        public required string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
        public required decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo Data de Previsão é obrigatório")]
        public required DateOnly DataPrevisao { get; set; }

        [Required(ErrorMessage = "O campo Categoria é obrigatório")]
        public required string Categoria { get; set; }

        public string? Observacao { get; set; }
    }
}