using ApiFinanceiro.Dtos;
using ApiFinanceiro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFinanceiro.Controllers
{
    [Route("/receitas")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private static List<Receita> ListaReceitas = new()
        {
            new Receita {
                Descricao = "Recebido Dividendos",
                Valor = 500,
                DataPrevisao = new DateOnly(2026, 03, 10),
                Situacao = "recebido",
                Categoria = "Investimentos"
            }
        };

        [HttpGet]
        public ActionResult FindAll() => Ok(ListaReceitas);

        [HttpPost]
        public ActionResult Create([FromBody] ReceitaDto dto)
        {
            var receita = new Receita
            {
                Descricao = dto.Descricao,
                Valor = dto.Valor,
                DataPrevisao = dto.DataPrevisao,
                Categoria = dto.Categoria,
                Observacao = dto.Observacao,
                Situacao = "pendente"
            };
            ListaReceitas.Add(receita);
            return Created("", receita);
        }

        [HttpGet("{id}")]
        public ActionResult FindById(Guid id)
        {
            var receita = ListaReceitas.Find(r => r.Id == id);
            return receita is null ? NotFound(new { mensagem = "Receita não encontrada!" }) : Ok(receita);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] ReceitaUpdate dto)
        {
            var receita = ListaReceitas.FirstOrDefault(r => r.Id == id);
            if (receita is null) return NotFound(new { mensagem = "Receita não encontrada!" });

            receita.Descricao = dto.Descricao;
            receita.Valor = dto.Valor;
            receita.DataPrevisao = dto.DataPrevisao;
            receita.DataRecebimento = dto.DataRecebimento;
            receita.Categoria = dto.Categoria;
            receita.Observacao = dto.Observacao;
            receita.Situacao = dto.Situacao;

            return Ok(receita);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(Guid id)
        {
            var receita = ListaReceitas.FirstOrDefault(r => r.Id == id);
            if (receita is null) return NotFound(new { mensagem = "Receita não encontrada!!" });

            ListaReceitas.Remove(receita);
            return NoContent();
        }
    }
}