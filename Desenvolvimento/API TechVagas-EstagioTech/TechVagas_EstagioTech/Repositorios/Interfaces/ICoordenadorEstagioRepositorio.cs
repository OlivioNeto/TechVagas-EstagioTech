using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface ICoordenadorEstagioRepositorio
    {
        Task<List<CoordenadorEstagioModel>> BuscarTodosCoordenadores();

        Task<CoordenadorEstagioModel> BuscarPorId(int id);

        Task<CoordenadorEstagioModel> Adicionar(CoordenadorEstagioModel coordenadorEstagioModel);

        Task<CoordenadorEstagioModel> Atualizar(CoordenadorEstagioModel coordenadorEstagioModel);

        Task<bool> Apagar(int id);
    }
}
