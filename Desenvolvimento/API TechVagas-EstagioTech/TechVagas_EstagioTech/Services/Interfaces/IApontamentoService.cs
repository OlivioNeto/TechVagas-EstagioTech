using TechVagas_EstagioTech.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
    public interface IApontamentoService
    {
        Task<IEnumerable<ApontamentoDto>> BuscarApontamento();
        Task<ApontamentoDto> BuscarPoId(int id);
        Task Adicionar (ApontamentoDto apontamentoDto);
        Task Atualizar(ApontamentoDto apontamenoDto);
        Task Apagar(int id);
    }
}
