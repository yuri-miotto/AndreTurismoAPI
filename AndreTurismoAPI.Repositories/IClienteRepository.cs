using AndreTurismoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoAPI.Repositories
{
    public interface IClienteRepository
    {
        Cliente Inserir(Cliente cliente);
        bool Atualizar(Cliente cliente);
        bool Deletar(int id);
        List<Cliente> Listar();
        Cliente ConsultarPorId(int id);
    }
}
