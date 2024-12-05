using TechVagas_EstagioTech.Objects.Model.Entities;

namespace TechVagas_EstagioTech.Repositorios.Interfaces
{
    public interface IContratoEstagioRepositorio
    {
        Task<List<ContratoEstagioModel>> BuscarPorMatricula(int idMatricula);
        Task<List<ContratoEstagioModel>> BuscarTodosContratoEstagios();

        Task<ContratoEstagioModel> BuscarPorId(int id);

        Task<ContratoEstagioModel> Adicionar(ContratoEstagioModel contratoestagioModel);

        Task<ContratoEstagioModel> Atualizar(ContratoEstagioModel contratoestagioModel);

        Task<bool> Apagar(int id);
    }
}
