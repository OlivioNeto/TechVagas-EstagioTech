using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("instituicaoensino")]
    public class InstituicaoEnsinoModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nomeinstituicao")]
        public string NomeInstituicao { get; set; }

        [Column("local")]
        public string Local {  get; set; }

        [Column("telefone")]
        public string Telefone { get; set; }

    }
}
