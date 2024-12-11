using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Objects.Interface;
using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Objects.Dtos.Entities
{
    public class CoordenadorEstagioDto : IStatus
    {
        [Key]
        public int idCoordenadorEstagio { get; set; }

        [Required(ErrorMessage = "Informe a data de cadastro do Coordenador")]
        public DateOnly? dataCadastro { get; set; }

        [Required(ErrorMessage = "Informe o nome do Coordenador")]
        public string nomeCoordenador { get; set; }

        [Required(ErrorMessage = "O status é requerido!")]
        public bool Status { get; set; }
        public void DisableAllOperations() => IStatusExtensions.DisableAllOperations(this);
        public void EnableAllOperations() => IStatusExtensions.EnableAllOperations(this);

        [JsonIgnore]
        [Column("coordenadorestagio")]
        public ICollection<CoordenadorEstagioModel>? CoordenadorEstagio { get; set; }

        [JsonIgnore]
        [Column("documento")]
        public ICollection<DocumentoModel>? Documento { get; set; }
    }
}
