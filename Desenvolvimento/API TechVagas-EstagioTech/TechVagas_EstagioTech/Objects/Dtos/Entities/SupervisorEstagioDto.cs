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

        public string nomeSupervisor { get; set; }

        public string statusSupervisor { get; set; }
    }
}