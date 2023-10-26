using AutoMapper;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Repositorios;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Services.Entities
{
	public class TipoDocumentoService : ITipoDocumentoService
	{
		private readonly ITipoDocumentoRepositorio _tipoDocumentoRepositorio;
		private readonly IMapper _mapper;

		public TipoDocumentoService(ITipoDocumentoRepositorio tipoDocumentoRepositorio, IMapper mapper)
		{
			_tipoDocumentoRepositorio = tipoDocumentoRepositorio;
			_mapper = mapper;
		}

		public async Task<TipoDocumentoDto> BuscarPorId(int id)
		{
			var tdocumento = await _tipoDocumentoRepositorio.BuscarPorId(id);
			return _mapper.Map<TipoDocumentoDto>(tdocumento);
		}

		public async Task<IEnumerable<TipoDocumentoDto>> BuscarTodosTipoDocumentos()
		{
			var tdocumento = await _tipoDocumentoRepositorio.BuscarTodosTipoDocumentos();
			return _mapper.Map<IEnumerable<TipoDocumentoDto>>(tdocumento);
		}
	}
}
