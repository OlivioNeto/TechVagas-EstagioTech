using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Objects.Dtos.Entities
{
    public class CoordenadorEstagioDto
    {
        [Key]
        public int idCoordenadorEstagio { get; set; }

        [Required(ErrorMessage = "Informe a data de cadastro do Coordenador")]
        public DateOnly? dataCadastro { get; set; }

        public bool StatusCoordenadorEstagio { get; set; }

        [JsonIgnore]
        [Column("coordenadorestagio")]
        public ICollection<CoordenadorEstagioModel>? CoordenadorEstagio { get; set; }
    }
}
