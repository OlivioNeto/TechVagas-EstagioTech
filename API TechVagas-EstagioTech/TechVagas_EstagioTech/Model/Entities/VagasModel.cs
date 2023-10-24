namespace TechVagas_EstagioTech.Model.Entities
{
	public class VagasModel
	{
		public int VagasId { get; set; }
		public int Quantidade { get; set; }
		public DateTime DataPublicacao { get; set; }
		public DateTime DataLimite { get; set; }
		public string? Localidade { get; set; }
		public string? Descricao { get; set; }
		public string? Titulo { get; set; }
		public string? LocalidadeTrabalho { get; set; }
		public string? HorarioEntrada { get; set; }
		public string? HorarioSaida { get; set; }
		public string? TotalHorasSemanis { get; set; }
	}
}
