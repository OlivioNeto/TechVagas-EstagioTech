using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface IDocumentoVersaoRepositorio
    {
        Task<List<DocumentoVersaoModel>> BuscarTodasVersoesDocumentos();

        Task<DocumentoVersaoModel> BuscarPorId(int id);

        Task<DocumentoVersaoModel> Adicionar(DocumentoVersaoModel documentoVersaoModel);

        Task<DocumentoVersaoModel> Atualizar(DocumentoVersaoModel documentoVersaoModel);

        Task<bool> Apagar(int id);
    }
}
