using ApiFinanceiro.Dtos;
using ApiFinanceiro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFinanceiro.Controllers
{
    [Route("/despesas")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        private static List<Despesa> ListaDespesas = new()
        {

            new Despesa {
                Descricao = "Internet",
                Valor = 150,Categoria = "Moradia",
                DataVencimento = new DateOnly(2026,03,15),
                Situacao = "Aberto"
            },
            new Despesa {
                Descricao = "Agua",
                Valor = 100,Categoria = "Moradia",
                DataVencimento = new DateOnly(2026,03,15),
                Situacao = "Aberto"
            }

        };
        [HttpGet]
        public ActionResult FindAll()
        {
            return Ok(ListaDespesas);
        }
        [HttpPost()]
        public ActionResult Create([FromBody] DespesaDto novaDespesa)
        {
            var despesa = new Despesa
            {
                Descricao = novaDespesa.Descricao,
                Valor = novaDespesa.Valor,
                Categoria = novaDespesa.Categoria,
                DataVencimento = novaDespesa.DataVencimento,
                Situacao = "Aberto"
            };
            ListaDespesas.Add(despesa);

            return Created("", novaDespesa);
        }

        [HttpGet("{id}")]
        public ActionResult FindById(Guid id)
        {
            var despesa = ListaDespesas.Find(d => d.Id == id);
            if (despesa is null)
            {
                return NotFound(new { mensagem = $"Despesa #{id} Não encontrada"});
            }
            return Ok(despesa);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] DespesaUpdate despesaDto)
        {
            var despesa = ListaDespesas.FirstOrDefault(d => d.Id == id);

            if (despesa is null)
            {
                return NotFound(new { mensagem = $"Despesa #{id} Não encontrada" });
            }
            var dataPagamento = new DateTime(despesaDto.DataPagamento.Year, despesaDto.DataPagamento.Month, despesaDto.DataPagamento.Day);
            
            despesa.Descricao = despesaDto.Descricao;
            despesa.DataVencimento = despesa.DataVencimento;
            despesa.Categoria = despesaDto.Categoria;
            despesa.Situacao = despesaDto.Situacao;
            despesa.DataPagamento = dataPagamento;

            return Ok(despesa);
        }
        [HttpDelete("{id}")]
        public ActionResult Remove(Guid id)
        {
            var despesa = ListaDespesas.FirstOrDefault(d => d.Id == id);

            if (despesa is null)
            {
                return NotFound(new { mensagem = $"Despesa #{id} Não encontrada" });
            }
            ListaDespesas.Remove(despesa);


            return NoContent();

            // fazer o de receitas
        }
    }
}
