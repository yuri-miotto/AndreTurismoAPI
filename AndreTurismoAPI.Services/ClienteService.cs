using AndreTurismoAPI.Models;
using AndreTurismoAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoAPI.Services
{
    public class ClienteService
    {
        private IClienteRepository clienteRepository;

        public ClienteService()
        {
            clienteRepository = new ClienteRepository();
        }

        public Cliente Inserir(Cliente cliente)
        {
            return clienteRepository.Inserir(cliente);
        }

        public bool Atualizar(Cliente cliente)
        {
            return clienteRepository.Atualizar(cliente);
        }

        public bool Deletar(int id)
        {
            return clienteRepository.Deletar(id);
        }

        public List<Cliente> Listar()
        {
            return clienteRepository.Listar();
        }

        public Cliente ConsultarPorId(int id)
        {
            return clienteRepository.ConsultarPorId(id);
        }
    }
}
