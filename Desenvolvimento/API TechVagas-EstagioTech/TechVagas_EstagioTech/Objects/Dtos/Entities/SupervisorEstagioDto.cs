using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Objects.Interface;
using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Objects.Dtos.Entities
{
    public class SupervisorEstagioDto : IStatus
    {
        [Key]
        public int idSupervisor { get; set; }

        public string nomeSupervisor { get; set; }

        [Required(ErrorMessage = "O status é requerido!")]
        public bool Status { get; set; }
        public void DisableAllOperations() => IStatusExtensions.DisableAllOperations(this);
        public void EnableAllOperations() => IStatusExtensions.EnableAllOperations(this);

        [JsonIgnore]
        public ConcedenteDto? Concedente { get; set; }
        public int concedenteId { get; set; }
    }
}