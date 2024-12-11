using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface IAlunoRepositorio
    {
        Task<AlunoModel> BuscarPorEmail(string email);
        Task<List<AlunoModel>> BuscarTodosAlunos();

        Task<AlunoModel> BuscarPorId(int id);

        Task<AlunoModel> Adicionar(AlunoModel alunoModel);

        Task<AlunoModel> Atualizar(AlunoModel alunoModel);

        Task<bool> Apagar(int id);
    }
}
