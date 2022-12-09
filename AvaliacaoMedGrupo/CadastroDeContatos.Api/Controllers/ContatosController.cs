using CadastroDeContatos.BLL;
using CadastroDeContatos.BLL.Interfaces;
using CadastroDeContatos.Domain.Contato;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CadastroDeContatos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private IBLLContatos BLLContatos;

        public ContatosController()
        {
            BLLContatos = new BLLContatos();
        }

        //Retorna todos os contatos ativos
        [HttpGet, Route("/ListaContatos")]
        public IActionResult ListarContatos()
        {
            return Ok(BLLContatos.ListarContatos());
        }

        //Retorna todos os contatos com informacoes e ativos
        [HttpGet, Route("/ContatoComInformacoes")]
        public IActionResult ListarContatosComInformacoes()
        {
            return Ok(BLLContatos.ListarContatosComInformacoes());
        }

        //Adiciona contato
        [HttpPost, Route("/InserirContato")]
        public IActionResult InserirContato([FromBody] Contato contato)
        {
            bool contatoInserido = BLLContatos.InserirContato(contato);

            if (contatoInserido != true)
            {
                return BadRequest();
            }
            return Ok(contato);
        }

        //Desativa contato
        [HttpPut, Route("/DesativaContato/{id:int}")]
        public IActionResult DesativaContato(int id)
        {
            BLLContatos.DesativaContato(id);
            return Ok();
        }

        //Ativa contato
        [HttpPut, Route("/AtivaContato/{id:int}")]
        public IActionResult AtivaContato(int id)
        {
            BLLContatos.AtivaContato(id);
            return Ok();
        }

        //Deleta contato
        [HttpDelete, Route("/DeletaContato/{id:int}")]
        public IActionResult DeletaContato(int id)
        {
            BLLContatos.DeletaContato(id);
            return Ok();
        }
    }
}
