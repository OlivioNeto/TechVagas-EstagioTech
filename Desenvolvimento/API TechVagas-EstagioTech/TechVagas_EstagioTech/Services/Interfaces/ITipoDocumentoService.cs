using TechVagas_EstagioTech.Objects.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
    public interface ITipoDocumentoService
	{
		Task<IEnumerable<TipoDocumentoDto>> BuscarTodosTipoDocumentos();
		Task<TipoDocumentoDto> BuscarPorId(int id);
		Task Adicionar(string descricaoTipoDocumento);
		Task Atualizar(TipoDocumentoDto tipoDocumentoDto);
		Task Apagar(int id);
	}
}
