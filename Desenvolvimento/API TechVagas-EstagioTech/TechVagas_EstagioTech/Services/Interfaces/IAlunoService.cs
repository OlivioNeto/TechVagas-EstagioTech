using TechVagas_EstagioTech.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
	public interface IAlunoService
	{
		Task<IEnumerable<AlunoDto>> BuscarTodosAlunos();
		Task<AlunoDto> BuscarPorId(int id);
		Task Adicionar(AlunoDto alunoDto);
		Task Atualizar(AlunoDto alunoDto);
		Task Apagar(int id);
	}
}
