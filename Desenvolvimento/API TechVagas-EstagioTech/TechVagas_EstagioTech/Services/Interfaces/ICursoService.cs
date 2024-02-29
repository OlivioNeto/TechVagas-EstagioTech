using TechVagas_EstagioTech.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
	public interface ICursoService
	{
		Task<IEnumerable<CursoDto>> BuscarTodosCursos();
		Task<CursoDto> BuscarPorId(int id);
		Task Adicionar(CursoDto cursoDto);
		Task Atualizar(CursoDto cursoDto);
		Task Apagar(int id);
	}
}
