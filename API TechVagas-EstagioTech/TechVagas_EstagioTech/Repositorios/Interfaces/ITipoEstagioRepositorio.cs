using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface ITipoEstagioRepositorio
    {
        Task<List<TipoEstagioModel>> BuscarTodosTipoEstagio();

        Task<TipoEstagioModel> BuscarPorId(int id);

        Task<TipoEstagioModel> Adicionar(TipoEstagioModel tipoEstagioModel);

        Task<TipoEstagioModel> Atualizar(TipoEstagioModel tipoEstagioModel);

        Task<bool> Apagar(int id);
    }
}
