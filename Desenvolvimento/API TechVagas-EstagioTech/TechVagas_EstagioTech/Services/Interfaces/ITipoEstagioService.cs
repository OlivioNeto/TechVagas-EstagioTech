using TechVagas_EstagioTech.Objects.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
    public interface ITipoEstagioService
	{
		Task<IEnumerable<TipoEstagioDto>> BuscarTodosTipoEstagio();
		Task<TipoEstagioDto> BuscarPorId(int id);
        Task Adicionar(string descricaoTipoEstagio);
        Task Atualizar(TipoEstagioDto tipoEstagioDto);
		Task Apagar(int id);
	}
}
