using AutoMapper;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Repositorios;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Services.Entities
{
    public class CoordenadorEstagioService : ICoordenadorEstagioService
    {
        private readonly ICoordenadorEstagioRepositorio _coordenadorEstagioRepositorio;
        private readonly IMapper _mapper;

        public CoordenadorEstagioService(ICoordenadorEstagioRepositorio coordenadorEstagioRepositorio, IMapper mapper)
        {
            _coordenadorEstagioRepositorio = coordenadorEstagioRepositorio;
            _mapper = mapper;
        }
        public async Task<CoordenadorEstagioDto> BuscarPorId(int id)
        {
            var coordenadorEstagio = await _coordenadorEstagioRepositorio.BuscarPorId(id);
            return _mapper.Map<CoordenadorEstagioDto>(coordenadorEstagio);
        }
        public async Task<IEnumerable<CoordenadorEstagioDto>> BuscarTodosCoordenadoresEstagio()
        {
            var coordenadorEstagio = await _coordenadorEstagioRepositorio.BuscarTodosCoordenadores();
            return _mapper.Map<IEnumerable<CoordenadorEstagioDto>>(coordenadorEstagio);
        }
        public async Task Adicionar(CoordenadorEstagioDto coordenadorEstagioDto)
        {
            var coordenadorEstagio = _mapper.Map<CoordenadorEstagioModel>(coordenadorEstagioDto);
            await _coordenadorEstagioRepositorio.Adicionar(coordenadorEstagio);
            coordenadorEstagioDto.idCoordenadorEstagio = coordenadorEstagio.idCoordenadorEstagio;
        }
        public async Task Atualizar(CoordenadorEstagioDto coordenadorEstagioDto)
        {
            var coordenadorEstagio = _mapper.Map<CoordenadorEstagioModel>(coordenadorEstagioDto);
            await _coordenadorEstagioRepositorio.Atualizar(coordenadorEstagio);
        }
        public async Task Apagar(int id)
        {
            await _coordenadorEstagioRepositorio.Apagar(id);
        }
    }
}
