using System.ComponentModel.DataAnnotations;

namespace ApiFinanceiro.Dtos
{
    public class ReceitaUpdate
    {
        [Required(ErrorMessage = "Descrição é Obrigatória!!")]
        [MinLength(5, ErrorMessage = "Obrigatório ter no minimo de 5 caracteres!!")]
        public required string Descricao { get; set; }

        [Required(ErrorMessage = "O campo valor é obrigatório!!")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero (0,00)")]
        public required decimal Valor { get; set; }

        public required DateOnly DataPrevisao { get; set; }

        public DateOnly? DataRecebimento { get; set; }

        [Required(ErrorMessage = "O campo categoria é obrigatório")]
        public required string Categoria { get; set; }

        public string? Observacao { get; set; }

        [Required(ErrorMessage = "O campo situação é obrigatório")]
        public required string Situacao { get; set; }
    }
}