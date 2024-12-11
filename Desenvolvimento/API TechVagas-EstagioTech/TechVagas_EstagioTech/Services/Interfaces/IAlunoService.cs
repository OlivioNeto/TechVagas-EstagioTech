using TechVagas_EstagioTech.Objects.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
    public interface IAlunoService
	{
		Task<AlunoDto> BuscarPorEmail(string email);

        Task<IEnumerable<AlunoDto>> BuscarTodosAlunos();
		Task<AlunoDto> BuscarPorId(int id);
		Task Adicionar(AlunoDto alunoDto);
		Task Atualizar(AlunoDto alunoDto);
		Task Apagar(int id);
	}
}
