using AndreTurismoAPI.Models;
using AndreTurismoAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AndreTurismoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _enderecoService;
        private CidadeService _cidadeService;

        public EnderecoController()
        {
            _enderecoService = new EnderecoService();
            _cidadeService = new CidadeService();
        }

        [HttpGet]
        public ActionResult<List<Endereco>> Listar() => _enderecoService.Listar();

        [HttpGet("{id}", Name = "ConsultarEnderecoPorId")]
        public ActionResult<Endereco> ConsultarPorId(int id) => _enderecoService.ConsultarPorId(id);

        [HttpPost]
        public Endereco Inserir(Endereco endereco)
        {
            endereco.Cidade = (endereco.Cidade.IdCidade == 0) ? _cidadeService.Inserir(endereco.Cidade) : _cidadeService.ConsultarPorId(endereco.Cidade.IdCidade);
            return _enderecoService.Inserir(endereco);
        }

        [HttpPut]
        public bool Atualizar(Endereco endereco) => _enderecoService.Atualizar(endereco);

        [HttpDelete]
        public bool Deletar(int id) => _enderecoService.Deletar(id);
    }
}
