using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface ISupervisorEstagioRepositorio
    {
        Task<List<SupervisorEstagioModel>> BuscarTodosSupervisorEstagio();

        Task<SupervisorEstagioModel> BuscarPorId(int id);

        Task<SupervisorEstagioModel> Adicionar(SupervisorEstagioModel supervisorEstagioModel);

        Task<SupervisorEstagioModel> Atualizar(SupervisorEstagioModel supervisorEstagioModel);

        Task<bool> Apagar(int id);
    }
}
