using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoAPI.Models
{
    public class Cliente
    {
        public readonly static string INSERIR = "insert into Cliente (Nome, Telefone, IdEndereco, DataCadastro) values (@Nome, @Telefone, @IdEndereco, @DataCadastro); select cast(scope_identity() as int)";
        public readonly static string ATUALIZAR = "update Cliente set Nome = @Nome, Telefone = @Telefone, IdEndereco = @IdEndereco, DataCadastro = @DataCadastro  where IdCliente = @IdCliente";
        public readonly static string DELETAR = "delete from Cliente where IdCliente = @IdCliente";
        public readonly static string CONSULTAR = "select cl.IdCliente, cl.Nome, cl.Telefone, cl.IdEndereco, cl.DataCadastro, e.Logradouro, e.Numero, e.Bairro, e.CEP, e.Complemento, e.IdCidade, e.DataCadastro, c.Descricao, c.DataCadastro" +
            "from Cliente cl inner join Endereco e on cl.IdEndereco = e.IdEndereco inner join Cidade c on e.IdCidade = c.IdCidade";
        public readonly static string CONSULTARPORID = "select cl.IdCliente, cl.Nome, cl.Telefone, cl.IdEndereco, cl.DataCadastro, e.Logradouro, e.Numero, e.Bairro, e.CEP, e.Complemento, e.IdCidade, e.DataCadastro, c.Descricao, c.DataCadastro" +
            "from Cliente cl inner join Endereco e on cl.IdEndereco = e.IdEndereco inner join Cidade c on e.IdCidade = c.IdCidade where IdCliente = @IdCliente";

        [Key]
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
