using AndreTurismoAPI.Models;
using AndreTurismoAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private CidadeService _cidadeService;

        public CidadeController()
        {
            _cidadeService = new CidadeService();
        }

        [HttpGet]
        public List<Cidade> Listar() => _cidadeService.Listar();

        [HttpGet("{id}", Name = "ConsultarCidadePorId")]
        public ActionResult<Cidade> ConsultarPorId(int id) => _cidadeService.ConsultarPorId(id);

        [HttpPost]
        public Cidade Inserir(Cidade cidade) => _cidadeService.Inserir(cidade);

        [HttpPut]
        public bool Atualizar(Cidade cidade) => _cidadeService.Atualizar(cidade);

        [HttpDelete]
        public bool Deletar(int id) => _cidadeService.Deletar(id);
    }
}
