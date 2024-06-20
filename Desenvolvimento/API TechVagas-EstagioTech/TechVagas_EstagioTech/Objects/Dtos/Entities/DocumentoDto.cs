using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Objects.Dtos.Entities
{
    public class DocumentoDto
    {
        [Key]
        public int idDocumento { get; set; }

        [Required(ErrorMessage = "Informe a descrição do documento")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? descricaoDocumento { get; set; }


        [Required(ErrorMessage = "Informe a situação do documento")]
        public string? situacaoDocumento { get; set; }

        [JsonIgnore]
        public CoordenadorEstagioDto? CoordenadorEstagio { get; set; }
        public int idCoordenadorEstagio { get; set; }

        [JsonIgnore]
        public TipoDocumentoDto? TipoDocumento { get; set; }
        public int idTipoDocumento { get; set; }

        [JsonIgnore]
        [Column("documento")]
        public ICollection<DocumentoModel>? Documento { get; set; }
    }
}
