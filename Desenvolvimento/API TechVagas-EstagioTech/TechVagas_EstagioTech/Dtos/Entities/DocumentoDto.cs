using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Dtos.Entities
{
	public class DocumentoDto
	{
        [Key]
        public int DocumentoId { get; set; }

		[Required(ErrorMessage = "Informe a descrição do documento")]
		[MinLength(3)]
		[MaxLength(100)]
		public string? descricaoDocumento { get; set; }


		[Required(ErrorMessage = "Informe a situação do documento")]
		public string? situacaoDocumento { get; set; }

        [JsonIgnore]
        [Column("documento")]
        public ICollection<DocumentoModel>? Documento { get; set; }


        [JsonIgnore]
        public ICollection<ContratoEstagioModel>? ContratoEstagios { get; set; }
        public int contratoestagioId { get; set; }
    }
}
