using TechVagas_EstagioTech.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
	public interface IDocumentoService
	{
		Task<IEnumerable<DocumentoDto>> BuscarTodosDocumentos();
		Task<DocumentoDto> BuscarPorId(int id);
		Task Adicionar(DocumentoDto documentoDto);
		Task Atualizar(DocumentoDto documentoDto);
		Task Apagar(int id);
	}
}
