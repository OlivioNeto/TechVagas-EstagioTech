using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface ITipoDocumentoRepositorio
    {
        Task<List<TipoDocumentoModel>> BuscarTodosTipoDocumentos();

        Task<TipoDocumentoModel> BuscarPorId(int id);

        Task<TipoDocumentoModel> Adicionar(TipoDocumentoModel tipoDocumentoModel);

        Task<TipoDocumentoModel> Atualizar(TipoDocumentoModel tipoDocumentoModel);

        Task<bool> Apagar(int id);
    }
}
