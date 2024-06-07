using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface IAlunoRepositorio
    {
        Task<List<AlunoModel>> BuscarTodosAlunos();

        Task<AlunoModel> BuscarPorId(int id);

        Task<AlunoModel> Adicionar(AlunoModel alunoModel);

        Task<AlunoModel> Atualizar(AlunoModel alunoModel);

        Task<bool> Apagar(int id);
    }
}
