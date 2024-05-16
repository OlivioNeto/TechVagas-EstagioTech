using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface IMatriculaRepositorio
    {
        Task<List<MatriculaModel>> BuscarTodasMatriculas();

        Task<MatriculaModel> BuscarPorId(int id);

        Task<MatriculaModel> Adicionar(MatriculaModel matriculaModel);

        Task<MatriculaModel> Atualizar(MatriculaModel matriculaModel);

        Task<bool> Apagar(int id);
    }
}
