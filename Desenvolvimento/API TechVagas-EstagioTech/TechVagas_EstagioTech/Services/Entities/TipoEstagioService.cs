using AutoMapper;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Objects.Model.Entities;
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

		public async Task<IEnumerable<TipoEstagioDto>> BuscarTodosTipoEstagio()
		{
			var tipoEstagio = await _tipoEstagioRepositorio.BuscarTodosTipoEstagio();
			return _mapper.Map<IEnumerable<TipoEstagioDto>>(tipoEstagio);
		}

		public async Task Adicionar(TipoEstagioDto tipoEstagioDto)
		{
			var tipoEstagio = _mapper.Map<TipoEstagioModel>(tipoEstagioDto);
			await _tipoEstagioRepositorio.Adicionar(tipoEstagio);
			tipoEstagioDto.idTipoEstagio = tipoEstagio.idTipoEstagio;
		}
        public async Task Adicionar(string descricaoTipoEstagio)
        {
            var tipoEstagio = new TipoEstagioModel() { descricaoTipoEstagio = descricaoTipoEstagio }; //mapeamento para converter a dto em model antes
            await _tipoEstagioRepositorio.Adicionar(tipoEstagio);
        }

        public async Task Atualizar(TipoEstagioDto tipoEstagioDto)
		{
			var tipoEstagio = _mapper.Map<TipoEstagioModel>(tipoEstagioDto);
			await _tipoEstagioRepositorio.Atualizar(tipoEstagio);
		}

		public async Task Apagar(int id)
		{
			await _tipoEstagioRepositorio.Apagar(id);
		}
	}
}
