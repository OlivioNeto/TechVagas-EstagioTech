using TechVagas_EstagioTech.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
	public interface ITipoDocumentoService
	{
		Task<IEnumerable<TipoDocumentoDto>> BuscarTodosTipoDocumentos();
		Task<TipoDocumentoDto> BuscarPorId(int id);
		Task Adicionar(TipoDocumentoDto tipoDocumentoDto);
		Task Atualizar(TipoDocumentoDto tipoDocumentoDto);
		Task Apagar(int id);
	}
}
