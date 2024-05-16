using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Objects.Dtos.Entities
{
    public class SupervisorEstagioDto
    {
        [Key]
        public int idSupervisor { get; set; }

        [Required(ErrorMessage = "Informe o Status do SupervisorEstagio")]

        public bool statusSupervisor { get; set; }

        //[JsonIgnore]
        //[Column("tipoestagioid")] 
        //public ICollection<TipoEstagioModel>? TipoEstagios { get; set; }
    }
}