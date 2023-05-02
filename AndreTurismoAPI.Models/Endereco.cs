using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoAPI.Models
{
    public class Endereco
    {
        public readonly static string INSERIR = "insert into Endereco (Logradouro, Numero, Bairro, CEP, Complemento, IdCidade, DataCadastro)" +
            "values (@Logradouro, @Numero, @Bairro, @CEP, @Complemento, @IdCidade, @DataCadastro); select cast(scope_identity() as int)";
        public readonly static string ATUALIZAR = "update Endereco set Logradouro = @Logradouro, Numero = @Numero, Bairro = @Bairro, CEP = @CEP, " +
            "Complemento = @Complemento, IdCidade = @IdCidade, DataCadastro = @DataCadastro where IdEndereco = @IdEndereco";
        public readonly static string DELETAR = "delete from Endereco where IdEndereco = @IdEndereco";
        public readonly static string CONSULTAR = "select e.IdEndereco, e.Logradouro, e.Numero, e.Bairro, e.CEP, e.Complemento, e.IdCidade, e.DataCadastro, c.Descricao, c.DataCadastro" +
            "from Endereco e inner join Cidade c on e.IdCidade = c.IdCidade";
        public readonly static string CONSULTARPORID = "select e.IdEndereco, e.Logradouro, e.Numero, e.Bairro, e.CEP, e.Complemento, e.IdCidade, e.DataCadastro, c.Descricao, c.DataCadastro" +
            "from Endereco e inner join Cidade c on e.IdCidade = c.IdCidade where IdEndereco = @IdEndereco";

        [Key]
        public int IdEndereco { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public Cidade Cidade { get; set; }
        public DateTime DataCadastro { get; set; }

        public Endereco() { }

        public Endereco(EnderecoDTO enderecoDTO)
        {
            this.Logradouro = enderecoDTO.Logradouro;
            this.CEP = enderecoDTO.CEP;
            this.Cidade = new Cidade() { Descricao = enderecoDTO.City };
        }
    }
}
