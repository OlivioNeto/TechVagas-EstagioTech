using TechVagas_EstagioTech.Objects.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
    public interface IDocumentoService
	{
        Task<List<DocumentoDto>> BuscarPorContrato(int idContrato);

        Task<IEnumerable<DocumentoDto>> BuscarTodosDocumentos();
		Task<DocumentoDto> BuscarPorId(int id);
        Task Adicionar(DocumentoDto documentoDto);
        Task Atualizar(DocumentoDto documentoDto);
		Task Apagar(int id);
	}
}
