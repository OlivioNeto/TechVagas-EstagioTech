using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface ITipoEstagioInterface
    {
        Task<List<TipoEstagioModel>> BuscarTodosTiposEstagios();

        Task<TipoEstagioModel> BuscarPorId(int id);

        Task<TipoEstagioModel> Adicionar(TipoEstagioModel tipoEstagio);

        Task<TipoEstagioModel> Atualizar(TipoEstagioModel tipoEstagio);

        Task<bool> Apagar(int id);
    }
}
