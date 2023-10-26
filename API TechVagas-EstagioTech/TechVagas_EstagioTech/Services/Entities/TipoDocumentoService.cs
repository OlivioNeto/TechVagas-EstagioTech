using AutoMapper;
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
	}
}
