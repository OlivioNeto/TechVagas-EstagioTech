using AutoMapper;
using TechVagas_EstagioTech.Dtos.Entities;
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


	}
}