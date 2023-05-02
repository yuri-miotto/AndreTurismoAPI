using AndreTurismoAPI.Models;
using AndreTurismoAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoAPI.Services
{
    public class EnderecoService
    {
        private IEnderecoRepository enderecoRepository;

        public EnderecoService()
        {
            enderecoRepository = new EnderecoRepository();
        }

        public Endereco Inserir(Endereco endereco)
        {
            return enderecoRepository.Inserir(endereco);
        }

        public bool Atualizar(Endereco endereco)
        {
            return enderecoRepository.Atualizar(endereco);
        }

        public bool Deletar(int id)
        {
            return enderecoRepository.Deletar(id);
        }

        public List<Endereco> Listar()
        {
            return enderecoRepository.Listar();
        }

        public Endereco ConsultarPorId(int id)
        {
            return enderecoRepository.ConsultarPorId(id);
        }
    }
}
