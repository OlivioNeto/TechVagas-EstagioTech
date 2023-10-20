using System.ComponentModel.DataAnnotations;

namespace TechVagas_EstagioTech.Dtos.Entities
{
	public class TipoDocumentoDto
	{
		public int idTipoDocumento { get; set; }

		[Required(ErrorMessage = "Informe a descrição de documento")]
		[MinLength(3)]
		[MaxLength(100)]
		public string? descricaoTipoDocumento { get; set; }
	}
}
