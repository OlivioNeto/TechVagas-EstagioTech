using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("usuario")]
    public class UsuarioModel
    {
        [Key]
        [Column("usuarioid")]
        public int UsuarioId { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("cpfcnpjpessoa")]
        public string CpfCnpj { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        public ICollection<SessaoModel>? Sessoes { get; set; }

        [Column("usertype")]
        [EnumDataType(typeof(UserTypeModel))]
        public UserTypeModel UserTypeModel { get; set; }

    }

}

