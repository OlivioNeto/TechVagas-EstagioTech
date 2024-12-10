using TechVagas_EstagioTech.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
    public interface IInstituicaoEnsinoService
    {
        Task<IEnumerable<InstituicaoEnsinoDto>> BuscarTodasInstituicoes();
        Task<InstituicaoEnsinoDto> BuscarPorId(int id);
        Task Adicionar(InstituicaoEnsinoDto instituicaoEnsinoDto);
        Task Atualizar(InstituicaoEnsinoDto instituicaoEnsinoDto);
        Task Apagar(int id);
    }
}
