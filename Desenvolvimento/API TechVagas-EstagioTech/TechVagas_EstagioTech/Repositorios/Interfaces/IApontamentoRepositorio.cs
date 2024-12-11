using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface IApontamentoRepositorio
    {
        Task<List<ApontamentoModel>> BuscarApontamento();

        Task<ApontamentoModel> BuscarPorId(int id);

        Task<ApontamentoModel> Adicionar(ApontamentoModel apontamentoModel);

        Task<ApontamentoModel> Atualizar(ApontamentoModel apontamentoModel);

        Task<bool> Apagar(int id);
    }
}
