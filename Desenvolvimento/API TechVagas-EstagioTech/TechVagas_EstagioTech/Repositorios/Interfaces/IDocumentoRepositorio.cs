using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface IDocumentoRepositorio
    {
        Task<List<DocumentoModel>> BuscarPorContrato(int idContrato);
        Task<List<DocumentoModel>> BuscarTodosDocumentos();

        Task<DocumentoModel> BuscarPorId(int id);

        Task<DocumentoModel> Adicionar(DocumentoModel documentoModel);

        Task<DocumentoModel> Atualizar(DocumentoModel documentoModel);

        Task<bool> Apagar(int id);
    }
}
