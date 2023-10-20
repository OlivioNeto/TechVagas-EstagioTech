using System.ComponentModel.DataAnnotations;

namespace TechVagas_EstagioTech.Dtos.Entities
{
	public class CargoDto
	{
		public int CargoId { get; set; }

		[Required(ErrorMessage = "E necessário uma descrição")]
		[MinLength(3)]
		[MaxLength(80)]
		public string? Descricao { get; set; }
		public string? Tipo { get; set; }
	}
}
