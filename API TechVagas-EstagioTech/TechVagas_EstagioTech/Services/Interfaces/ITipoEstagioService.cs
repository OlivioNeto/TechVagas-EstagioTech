using TechVagas_EstagioTech.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
	public interface ITipoEstagioService
	{
		Task<IEnumerable<TipoEstagioDto>> BuscarTodosTipoEstagio();
		Task<TipoEstagioDto> BuscarPorId(int id);
		Task Adicionar(TipoEstagioDto tipoEstagioDto);
		Task Atualizar(TipoEstagioDto tipoEstagioDto);
		Task Apagar(int id);
	}
}
