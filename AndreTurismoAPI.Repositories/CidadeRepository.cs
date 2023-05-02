using AndreTurismoAPI.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoAPI.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\projetos\AndreTurismoAPI\BancoDeDados\andreturismo.mdf";
        public bool Atualizar(Cidade cidade)
        {
            var status = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Execute(Cidade.ATUALIZAR, cidade);
                status = true;
            }
            return status;
        }

        public Cidade ConsultarPorId(int id)
        {
            using (var db = new SqlConnection(_conn))
            {
                var cidade = db.QueryFirstOrDefault<Cidade>(Cidade.CONSULTARPORID, new { @IdCidade = id });
                return (Cidade)cidade;
            }
        }

        public bool Deletar(int id)
        {
            var status = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Execute(Cidade.DELETAR, new { @IdCidade = id }); ;
                status = true;
            }
            return status;
        }

        public Cidade Inserir(Cidade cidade)
        {
            var idCidade = 0;

            using (var db = new SqlConnection(_conn))
            {
                idCidade = db.ExecuteScalar<int>(Cidade.INSERIR, cidade);
            }
            cidade.IdCidade = idCidade;
            return cidade;
        }

        public List<Cidade> Listar()
        {
            using (var db = new SqlConnection(_conn))
            {
                var lst = db.Query<Cidade>(Cidade.CONSULTAR);
                return (List<Cidade>)lst;
            }
        }
    }
}
