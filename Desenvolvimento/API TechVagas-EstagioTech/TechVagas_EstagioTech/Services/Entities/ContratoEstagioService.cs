using AutoMapper;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Services.Entities
{
    public class ContratoEstagioService : IContratoEstagioService
    {
        private readonly IContratoEstagioRepositorio _contratoEstagioRepositorio;
        private readonly IMapper _mapper;

        public ContratoEstagioService(IContratoEstagioRepositorio contratoEstagioRepositorio, IMapper mapper)
        {
            _contratoEstagioRepositorio = contratoEstagioRepositorio;
            _mapper = mapper;
        }

        public async Task<List<ContratoEstagioDto>> BuscarPorMatricula(int idMatricula)
        {
            var contratoEstagio = await _contratoEstagioRepositorio.BuscarPorMatricula(idMatricula);
            return _mapper.Map<List<ContratoEstagioDto>>(contratoEstagio);
        }
        public async Task<ContratoEstagioDto> BuscarPorId(int id)
        {
            var contratoEstagio = await _contratoEstagioRepositorio.BuscarPorId(id);
            return _mapper.Map<ContratoEstagioDto>(contratoEstagio);
        }
        public async Task<IEnumerable<ContratoEstagioDto>> BuscarTodosContratoEstagios()
        {
            var contratoEstagio = await _contratoEstagioRepositorio.BuscarTodosContratoEstagios();
            return _mapper.Map<IEnumerable<ContratoEstagioDto>>(contratoEstagio);
        }
        public async Task Adicionar(ContratoEstagioDto contratoestagioDto)
        {
            var contratoEstagio = _mapper.Map<ContratoEstagioModel>(contratoestagioDto);
            await _contratoEstagioRepositorio.Adicionar(contratoEstagio);
            contratoestagioDto.idContratoEstagio = contratoEstagio.idContratoEstagio;
        }
        public async Task Atualizar(ContratoEstagioDto contratoestagioDto)
        {
            var contratoestagio = _mapper.Map<ContratoEstagioModel>(contratoestagioDto);
            await _contratoEstagioRepositorio.Atualizar(contratoestagio);
        }

        public async Task Apagar(int id)
        {
            await _contratoEstagioRepositorio.Apagar(id);
        }    
    }
}
