using TechVagas_EstagioTech.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface IConcedenteRepositorio
    {
        Task<List<ConcedenteModel>> BuscarTodosConcedentes();

        Task<ConcedenteModel> BuscarPorId(int id);

        Task<ConcedenteModel> Adicionar(ConcedenteModel concedenteModel);

        Task<ConcedenteModel> Atualizar(ConcedenteModel concedenteModel);

        Task<bool> Apagar(int id);
    }
}
