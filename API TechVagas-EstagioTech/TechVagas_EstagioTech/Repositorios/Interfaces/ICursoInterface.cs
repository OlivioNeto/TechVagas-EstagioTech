using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface ICursoInterface
    {
        Task<List<CursoModel>> BuscarTodosTiposEstagios();

        Task<CursoModel> BuscarPorId(int id);

        Task<CursoModel> Adicionar(CursoModel curso);

        Task<CursoModel> Atualizar(CursoModel curso);

        Task<bool> Apagar(int id);
    }
}
