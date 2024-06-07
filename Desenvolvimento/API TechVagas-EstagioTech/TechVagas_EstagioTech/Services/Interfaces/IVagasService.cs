using TechVagas_EstagioTech.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
	public interface IVagasService
	{
		Task<IEnumerable<VagasDto>> BuscarTodasVagas();
		Task<VagasDto> BuscarPorId(int id);
		Task Adicionar(VagasDto vagasDto);
		Task Atualizar(VagasDto vagasDto);
		Task Apagar(int id);
	}
}
