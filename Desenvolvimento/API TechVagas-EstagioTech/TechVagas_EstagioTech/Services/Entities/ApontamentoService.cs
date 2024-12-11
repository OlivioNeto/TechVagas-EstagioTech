using AutoMapper;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Services.Entities
{
    public class ApontamentoService : IApontamentoService
    {
        private readonly IApontamentoRepositorio _apontamentoRepositorio;
        private readonly IMapper _mapper;

        public ApontamentoService(IApontamentoRepositorio apontamentoRepositorio, IMapper mapper)
        {
            _apontamentoRepositorio = apontamentoRepositorio;
            _mapper = mapper;
        }

        public async Task<ApontamentoDto> BuscarPoId(int id)
        {
            var apontamento = await _apontamentoRepositorio.BuscarPorId(id);
            return _mapper.Map<ApontamentoDto>(apontamento);
        }
        public async Task<IEnumerable<ApontamentoDto>> BuscarApontamento()
        {
            var apontamento = await _apontamentoRepositorio.BuscarApontamento();
            return _mapper.Map<IEnumerable<ApontamentoDto>>(apontamento);
        }

        public async Task Adicionar(ApontamentoDto apontamentoDto)
        {
            var apontamento = _mapper.Map<ApontamentoModel>(apontamentoDto);
            await _apontamentoRepositorio.Adicionar(apontamento);
            apontamentoDto.idApontamento = apontamento.idApontamento;
        }
        public async Task Atualizar(ApontamentoDto apontamenoDto)
        {
            var apontamento = _mapper.Map<ApontamentoModel>(apontamenoDto);
            await _apontamentoRepositorio.Atualizar(apontamento);
        }
        public async Task Apagar(int id)
        {
            await _apontamentoRepositorio.Apagar(id);
        } 
    }
}
