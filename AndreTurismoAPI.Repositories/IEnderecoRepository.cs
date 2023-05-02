using AndreTurismoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoAPI.Repositories
{
    public interface IEnderecoRepository
    {
        Endereco Inserir(Endereco endereco);
        bool Atualizar(Endereco endereco);
        bool Deletar(int id);
        List<Endereco> Listar();
        Endereco ConsultarPorId(int id);
    }
}
