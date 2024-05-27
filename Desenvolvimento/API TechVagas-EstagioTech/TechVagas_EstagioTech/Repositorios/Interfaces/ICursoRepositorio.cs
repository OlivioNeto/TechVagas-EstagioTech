using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface ICursoRepositorio
    {
        Task<List<CursoModel>> BuscarTodosCursos();

        Task<CursoModel> BuscarPorId(int id);

        Task<CursoModel> Adicionar(CursoModel cursoModel);

        Task<CursoModel> Atualizar(CursoModel cursoModel);

        Task<bool> Apagar(int id);
    }
}
