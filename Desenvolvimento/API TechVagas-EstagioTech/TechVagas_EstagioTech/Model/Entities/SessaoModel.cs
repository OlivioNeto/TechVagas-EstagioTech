using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("sessao")]
    public class SessaoModel
    {
        [Column("sessaoid")]
        public int SessaoId { get; set; }

        [Column("tokensessao")]
        public string TokenSessao { get; set; }

        [Column("statussessao")]
        public bool StatusSessao { get; set; }

        [Column("emailusuario")]
        public string EmailUsuario { get; set; }

        [Column("nomeusuario")]
        public string NomeUsuario { get; set; }

        [Column("nivelacesso")]
        public string NivelAcesso { get; set; }

        public UsuarioModel? UsuarioModel { get; set; }

        [ForeignKey("usuarioid")]
        public int UsuarioId { get; set; }
    }
}
