using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("usuario")]
    public class UsuarioModel
    {
        [Column("idusuario")]
        public int usuarioId { get; set; }

        [Column("nomeusuario")]
        public string NomeUsuario { get; set; }

        [Column("emailusuario")]
        public string EmailUsuario { get; set; }

        [Column("senhausuario")]
        public string SenhaUsuario { get; set; }

        [Column("statususuario")]
        public Boolean StatusUsuario { get; set; }

        public TipoUsuarioModel? TipoUsuario { get; set; }

        [ForeignKey("idtipousuario")]
        public int IdTipoUsuario { get; set; }

    }
}
