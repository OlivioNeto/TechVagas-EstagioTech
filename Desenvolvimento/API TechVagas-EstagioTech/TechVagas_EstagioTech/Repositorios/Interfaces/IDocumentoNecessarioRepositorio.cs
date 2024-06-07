using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface IDocumentoNecessarioRepositorio
    {
        Task<List<DocumentoNecessarioModel>> BuscarTodosDocumentosNecessarios();

        Task<DocumentoNecessarioModel> BuscarPorId(int id);

        Task<DocumentoNecessarioModel> Adicionar(DocumentoNecessarioModel documentoNecessarioModel);

        Task<DocumentoNecessarioModel> Atualizar(DocumentoNecessarioModel documentoNecessarioModel);

        Task<bool> Apagar(int id);

        
    }
}
