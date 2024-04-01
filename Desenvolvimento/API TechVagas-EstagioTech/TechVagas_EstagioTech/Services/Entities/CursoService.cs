using AutoMapper;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Services.Entities
{
	public class CursoService : ICursoService
	{
		private readonly ICursoRepositorio _cursoRepositorio;
		private readonly IMapper _mapper;

		public CursoService(ICursoRepositorio cursoRepositorio, IMapper mapper)
		{
			_cursoRepositorio = cursoRepositorio;
			_mapper = mapper;
		}

		public async Task<CursoDto> BuscarPorId(int id)
		{
			var curso = await _cursoRepositorio.BuscarPorId(id);
			return _mapper.Map<CursoDto>(curso);
		}

		public async Task<IEnumerable<CursoDto>> BuscarTodosCursos()
		{
			var curso = await _cursoRepositorio.BuscarTodosCursos();
			return _mapper.Map<IEnumerable<CursoDto>>(curso);
		}

		public async Task Adicionar(CursoDto cursoDto)
		{
			var curso = _mapper.Map<CursoModel>(cursoDto);
			await _cursoRepositorio.Adicionar(curso);
			cursoDto.idCurso = curso.idCurso;
		}

		public async Task Atualizar(CursoDto cursoDto)
		{
			var curso = _mapper.Map<CursoModel>(cursoDto);
			await _cursoRepositorio.Atualizar(curso);
		}

		public async Task Apagar(int id)
		{
			await _cursoRepositorio.Apagar(id);
		}

	}
}