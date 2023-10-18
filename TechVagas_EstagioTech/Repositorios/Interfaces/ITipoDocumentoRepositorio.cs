using TechVagas_EstagioTech.Model;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface ITipoDocumentoRepositorio
    {
        Task<List<TipoDocumentoModel>> BuscarTodosTiposDocumentos();

        Task<TipoDocumentoModel> BuscarPorId(int id);

        Task<TipoDocumentoModel> Adicionar(TipoDocumentoModel tipoDocumento);

        Task<TipoDocumentoModel> Atualizar(TipoDocumentoModel tipoDocumento);

        Task<bool> Apagar(int id);
    }
}
