using TechVagas_EstagioTech.Objects.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
    public interface IContratoEstagioService
    {
        Task<List<ContratoEstagioDto>> BuscarPorMatricula(int idMatricula);
        Task<IEnumerable<ContratoEstagioDto>> BuscarTodosContratoEstagios();
        Task<ContratoEstagioDto> BuscarPorId(int id);
        Task Adicionar(ContratoEstagioDto contratoestagioDto);
        Task Atualizar(ContratoEstagioDto contratoestagioDto);
        Task Apagar(int id);
    }
}
