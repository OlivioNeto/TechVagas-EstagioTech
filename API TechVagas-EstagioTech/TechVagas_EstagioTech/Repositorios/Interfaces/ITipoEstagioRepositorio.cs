using TechVagas_EstagioTech.Model;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface ITipoEstagioRepositorio
    {
        Task<List<TipoEstagioModel>> BuscarTodosTiposEstagios();

        Task<TipoEstagioModel> BuscarPorId(int id);

        Task<TipoEstagioModel> Adicionar(TipoEstagioModel tipoEstagio);

        Task<TipoEstagioModel> Atualizar(TipoEstagioModel tipoEstagio);

        Task<bool> Apagar(int id);
    }
}
