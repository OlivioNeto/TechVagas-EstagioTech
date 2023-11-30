using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    public class UsuarioDto
    {
        public int usuarioId { get; set; }

        [Required(ErrorMessage = "O nome é requerido!")]
        [MinLength(10)]
        [MaxLength(70)]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "O e-mail é requerido!")]
        [EmailAddress]
        public string EmailUsuario { get; set; }

        [Required(ErrorMessage = "A senha é requerida!")]
        [MinLength(6)]
        [MaxLength(50)]
        public string SenhaUsuario { get; set; }

        public Boolean StatusUsuario { get; set; }


        [JsonIgnore]
        public TipoUsuarioDto? TipoUsuarioDto { get; set; }

        public int tipoUsuarioId { get; set; }
    }
}
