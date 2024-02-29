using TechVagas_EstagioTech.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
    public interface IDocumentoNecessarioService
    {
        Task<IEnumerable<DocumentoNecessarioDto>> BuscarTodosDocumentosNecessarios();
        Task<DocumentoNecessarioDto> BuscarPorId(int id);
        Task Adicionar(DocumentoNecessarioDto documentoNecessarioDto);
        Task Atualizar(DocumentoNecessarioDto documentoNecessarioDto);
        Task Apagar(int id);
    }
}
