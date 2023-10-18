using System.ComponentModel.DataAnnotations;

namespace TechVagas_EstagioTech.Model
{
	public class CargoModel
	{
		[Key]
		public int CargoId { get; set; }
		public string Descricao { get; set;}
		public string Tipo { get; set;}
	}
}
