using TechVagas_EstagioTech.Objects.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
    public interface IDocumentoVersaoService
    {
        Task<DocumentoVersaoDto> BuscarPorDocumento(int idDocumento);
        Task<IEnumerable<DocumentoVersaoDto>> BuscarTodosTipoDocumentos();
        Task<DocumentoVersaoDto> BuscarPorId(int id);
        Task Adicionar(DocumentoVersaoDto documentoVersaoDto);
        Task Atualizar(DocumentoVersaoDto documentoVersaoDto);
        Task Apagar(int id);
    }
}
