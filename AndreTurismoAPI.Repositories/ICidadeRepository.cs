using AndreTurismoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoAPI.Repositories
{
    public interface ICidadeRepository
    {
        Cidade Inserir(Cidade cidade);
        bool Atualizar(Cidade cidade);
        bool Deletar(int id);
        List<Cidade> Listar();
        Cidade ConsultarPorId(int id);
    }
}
