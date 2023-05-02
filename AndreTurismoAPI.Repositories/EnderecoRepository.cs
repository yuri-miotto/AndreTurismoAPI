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
    public class EnderecoRepository : IEnderecoRepository
    {
        private string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\projetos\AndreTurismoAPI\BancoDeDados\andreturismo.mdf";
        public bool Atualizar(Endereco endereco)
        {
            var status = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Execute(Endereco.ATUALIZAR, endereco);
                status = true;
            }
            return status;
        }

        public Endereco ConsultarPorId(int id)
        {
            using (var db = new SqlConnection(_conn))
            {
                var e = db.Query<Endereco, Cidade, Endereco>(Endereco.CONSULTAR, (endereco, cidade) =>
                {
                    endereco.Cidade = cidade;
                    return endereco;
                }, splitOn: "IdCidade");
                return e.First();;
            }
        }

        public bool Deletar(int id)
        {
            var status = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Execute(Endereco.DELETAR, new { @IdEndereco = id }); ;
                status = true;
            }
            return status;
        }

        public Endereco Inserir(Endereco endereco)
        {
            var idEndereco = 0;

            using (var db = new SqlConnection(_conn))
            {
                idEndereco = db.ExecuteScalar<int>(Endereco.INSERIR, new
                {
                    @Logradouro = endereco.Logradouro,
                    @Numero = endereco.Numero,
                    @Bairro = endereco.Bairro,
                    @CEP = endereco.CEP,
                    @Complemento = endereco.Complemento,
                    @IdCidade = endereco.Cidade.IdCidade,
                    @DataCadastro = endereco.DataCadastro
                });
            }
            endereco.IdEndereco = idEndereco;
            return endereco;
        }

        public List<Endereco> Listar()
        {
            using (var db = new SqlConnection(_conn))
            {
                var enderecos = db.Query<Endereco, Cidade, Endereco>(Endereco.CONSULTAR, (endereco, cidade) =>
                {
                    endereco.Cidade = cidade;
                    return endereco;
                }, splitOn: "IdCidade");
                return (List<Endereco>)enderecos;
            }
        }
    }
}
