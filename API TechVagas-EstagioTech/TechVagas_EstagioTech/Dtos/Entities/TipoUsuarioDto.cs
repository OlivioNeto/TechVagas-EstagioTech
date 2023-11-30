using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    public class TipoUsuarioDto
    {
        public int tipoUsuarioId { get; set; }

        [Required(ErrorMessage = "O nível de acesso é requerido!")]
        [MinLength(1)]
        [MaxLength(1)]
        public string NivelAcesso { get; set; }

        [Required(ErrorMessage = "O nome do tipo de usuário é requerido!")]
        [MinLength(3)]
        [MaxLength(20)]
        public string NomeTipoUsuario { get; set; }

        [Required(ErrorMessage = "A descrição é requerida!")]
        [MinLength(5)]
        [MaxLength(300)]
        public string DescricaoTipoUsuario { get; set; }

        [JsonIgnore]
        public ICollection<UsuarioDto>? UsuariosDto { get; set; }

    }
}
