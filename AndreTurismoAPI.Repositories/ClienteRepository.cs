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
    public class ClienteRepository : IClienteRepository
    {
        private string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\projetos\AndreTurismoAPI\BancoDeDados\andreturismo.mdf";
        public bool Atualizar(Cliente cliente)
        {
            var status = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Execute(Cliente.ATUALIZAR, cliente);
                status = true;
            }
            return status;
        }

        public Cliente ConsultarPorId(int id)
        {
            using (var db = new SqlConnection(_conn))
            {
                var c = db.Query<Cliente, Endereco, Cidade, Cliente>(Cliente.CONSULTAR, (cliente, endereco, cidade) =>
                {
                    cliente.Endereco = endereco;
                    cliente.Endereco.Cidade = cidade;
                    return cliente;
                }, splitOn: "IdEndereco, IdCidade");
                return c.First();
            }
        }

        public bool Deletar(int id)
        {
            var status = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Execute(Cliente.DELETAR, new { @IdCliente = id }); ;
                status = true;
            }
            return status;
        }

        public Cliente Inserir(Cliente cliente)
        {
            var idCliente = 0;

            using (var db = new SqlConnection(_conn))
            {
                idCliente = db.ExecuteScalar<int>(Cliente.INSERIR, new
                {
                    @Nome = cliente.Nome,
                    @Telefone = cliente.Telefone,
                    @IdEndereco = cliente.Endereco.IdEndereco,
                    @DataCadastro = cliente.DataCadastro
                });
            }
            cliente.IdCliente = idCliente;
            return cliente;
        }

        public List<Cliente> Listar()
        {
            using (var db = new SqlConnection(_conn))
            {
                var clientes = db.Query<Cliente, Endereco, Cidade, Cliente>(Cliente.CONSULTAR, (cliente, endereco, cidade) =>
                {
                    cliente.Endereco = endereco;
                    cliente.Endereco.Cidade = cidade;
                    return cliente;
                }, splitOn: "IdEndereco, IdCidade");
                return (List<Cliente>)clientes;
            }
        }
    }
}
