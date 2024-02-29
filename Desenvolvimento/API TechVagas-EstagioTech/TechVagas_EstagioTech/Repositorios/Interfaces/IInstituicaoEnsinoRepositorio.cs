using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface IInstituicaoEnsinoRepositorio
    {
        Task<List<InstituicaoEnsinoModel>> BuscarTodasInstituicoes();

        Task<InstituicaoEnsinoModel> BuscarPorId(int id);

        Task<InstituicaoEnsinoModel> Adicionar(InstituicaoEnsinoModel instituicaoEnsinoModel);

        Task<InstituicaoEnsinoModel> Atualizar(InstituicaoEnsinoModel instituicaoEnsinoModel);

        Task<bool> Apagar(int id);
    }
}
