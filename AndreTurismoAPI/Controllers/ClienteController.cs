using AndreTurismoAPI.Models;
using AndreTurismoAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ClienteService _clienteService;
        private EnderecoService _enderecoService;
        private CidadeService _cidadeService;        

        public ClienteController()
        {
            _clienteService = new ClienteService();
            _enderecoService = new EnderecoService();
            _cidadeService = new CidadeService();            
        }

        [HttpGet]
        public ActionResult<List<Cliente>> Listar() => _clienteService.Listar();

        [HttpGet("{id}", Name = "ConsultarClientePorId")]
        public ActionResult<Cliente> ConsultarPorId(int id) => _clienteService.ConsultarPorId(id);

        [HttpPost]
        public Cliente Inserir(Cliente cliente)
        {
            cliente.Endereco.Cidade = (cliente.Endereco.Cidade.IdCidade == 0) ? _cidadeService.Inserir(cliente.Endereco.Cidade) : _cidadeService.ConsultarPorId(cliente.Endereco.Cidade.IdCidade);
            cliente.Endereco = (cliente.Endereco.IdEndereco == 0) ? _enderecoService.Inserir(cliente.Endereco) : _enderecoService.ConsultarPorId(cliente.Endereco.IdEndereco);
            return _clienteService.Inserir(cliente);
        }

        [HttpPut]
        public bool Atualizar(Cliente cliente) => _clienteService.Atualizar(cliente);

        [HttpDelete]
        public bool Deletar(int id) => _clienteService.Deletar(id);
    }
}
