using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface IVagasRepositorio
    {
        Task<List<VagasModel>> BuscarTodasVagas();

        Task<VagasModel> BuscarPorId(int id);

        Task<VagasModel> Adicionar(VagasModel vagasModel);

        Task<VagasModel> Atualizar(VagasModel vagasModel);

        Task<bool> Apagar(int id);

	}
}
