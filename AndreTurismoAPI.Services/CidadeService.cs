using AndreTurismoAPI.Models;
using AndreTurismoAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoAPI.Services
{
    public class CidadeService
    {
        private ICidadeRepository cidadeRepository;

        public CidadeService()
        {
            cidadeRepository = new CidadeRepository();
        }

        public Cidade Inserir(Cidade cidade)
        {
            return cidadeRepository.Inserir(cidade);
        }

        public bool Atualizar(Cidade cidade)
        {
            return cidadeRepository.Atualizar(cidade);
        }

        public bool Deletar(int id)
        {
            return cidadeRepository.Deletar(id);
        }

        public List<Cidade> Listar()
        {
            return cidadeRepository.Listar();
        }

        public Cidade ConsultarPorId(int id)
        {
            return cidadeRepository.ConsultarPorId(id);
        }
    }
}
