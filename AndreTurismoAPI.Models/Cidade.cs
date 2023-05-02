using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoAPI.Models
{
    public class Cidade
    {
        public readonly static string INSERIR = "insert into Cidade (Descricao, DataCadastro) values (Descricao, @DataCadastro); select cast(scope_identity() as int)";
        public readonly static string ATUALIZAR = "update Cidade set Descricao = @Descricao, DataCadastro = @DataCadastro where IdCidade = @IdCidade";
        public readonly static string DELETAR = "delete from Cidade where IdCidade = @IdCidade";
        public readonly static string CONSULTAR = "select IdCidade, Descricao, DataCadastro from Cidade";
        public readonly static string CONSULTARPORID = "select IdCidade, Descricao, DataCadastro from Cidade where IdCidade = @IdCidade";

        [Key]
        public int IdCidade { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
