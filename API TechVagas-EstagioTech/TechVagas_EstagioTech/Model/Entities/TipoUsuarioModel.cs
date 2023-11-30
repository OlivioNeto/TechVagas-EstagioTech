using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("tipousuario")]
    public class TipoUsuarioModel
    {
        [Column("idtipousuario")]
        public int TipoUsuarioId { get; set; }

        [Column("nivelacesso")]
        public string NivelAcesso { get; set; }

        [Column("nometipousuario")]
        public string NomeTipoUsuario { get; set; }

        [Column("descricaotipousuario")]
        public string DescricaoTipoUsuario { get; set; }

        public ICollection<UsuarioModel>? Usuarios { get; set; }

    }
}
