using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface IVagasInteface
    {
        Task<List<VagasModel>> BuscarTodasVagas();

        Task<VagasModel> BuscarPorId(int id);

        Task<VagasModel> Adicionar(VagasDto vagasDto);

        Task<VagasModel> Atualizar(VagasDto vagasDto);

        Task<bool> Apagar(int id);
    }
}
