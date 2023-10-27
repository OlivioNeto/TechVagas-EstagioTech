using AutoMapper;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Repositorios;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Services.Entities
{
	public class TipoEstagioService : ITipoEstagioService
	{
		private readonly ITipoEstagioRepositorio _tipoEstagioRepositorio;
		private readonly IMapper _mapper;

		public TipoEstagioService(ITipoEstagioRepositorio tipoEstagioRepositorio, IMapper mapper)
		{
			_tipoEstagioRepositorio = tipoEstagioRepositorio;
			_mapper = mapper;
		}

		public async Task<TipoEstagioDto> BuscarPorId(int id)
		{
			var tipoEstagio = await _tipoEstagioRepositorio.BuscarPorId(id);
			return _mapper.Map<TipoEstagioDto>(tipoEstagio);
		}
	}
}
