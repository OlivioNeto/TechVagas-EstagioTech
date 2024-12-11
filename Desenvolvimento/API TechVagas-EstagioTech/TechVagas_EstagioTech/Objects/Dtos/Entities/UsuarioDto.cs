using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Objects.Enums;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    public class UsuarioDto
    {
        [Key]
        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public string CpfCnpj { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        [JsonIgnore]
        public ICollection<SessaoDto>? Sessoes { get; set; }

        [EnumDataType(typeof(UserType))]
        public UserType UserType { get; set; }
    }


}
