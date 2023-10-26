using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface ICursoRepositorio
    {
        Task<List<CursoModel>> BuscarTodosCursos();

        Task<CursoModel> BuscarPorId(int id);

        Task<CursoModel> Adicionar(CursoModel curso);

        Task<CursoModel> Atualizar(CursoModel curso);

        Task<bool> Apagar(int id);
    }
}
