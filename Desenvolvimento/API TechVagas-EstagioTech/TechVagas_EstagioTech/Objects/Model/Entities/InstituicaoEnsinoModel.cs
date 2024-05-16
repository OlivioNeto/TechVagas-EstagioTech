using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Objects.Model.Entities
{
    [Table("instituicaoensino")]
    public class InstituicaoEnsinoModel
    {
        [Key]
        [Column("id")]
        public int idInstituicaoEnsino { get; set; }

        [Column("nomeinstituicao")]
        public string NomeInstituicao { get; set; }

        [Column("local")]
        public string LocalInstituicao { get; set; }

        [Column("telefone")]
        public string TelefoneInstituicao { get; set; }

    }
}
