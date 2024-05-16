using AutoMapper;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Repositorios;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Services.Entities
{
    public class SupervisorEstagioService : ISupervisorEstagioService
    {
        private readonly ISupervisorEstagioRepositorio _supervisorEstagioRepositorio;
        private readonly IMapper _mapper;

        public SupervisorEstagioService(ISupervisorEstagioRepositorio supervisorEstagioRepositorio, IMapper mapper)
        {
            _supervisorEstagioRepositorio = supervisorEstagioRepositorio;
            _mapper = mapper;
        }

        public async Task<SupervisorEstagioDto> BuscarPorId(int id)
        {
            var supervisorEstagio = await _supervisorEstagioRepositorio.BuscarPorId(id);
            return _mapper.Map<SupervisorEstagioDto>(supervisorEstagio);
        }

        public async Task<IEnumerable<SupervisorEstagioDto>> BuscarTodosSupervisorEstagio()
        {
            var supervisorEstagio = await _supervisorEstagioRepositorio.BuscarTodosSupervisorEstagio();
            return _mapper.Map<IEnumerable<SupervisorEstagioDto>>(supervisorEstagio);
        }

        public async Task Adicionar(SupervisorEstagioDto supervisorEstagioDto)
        {
            var supervisorEstagio = _mapper.Map<SupervisorEstagioModel>(supervisorEstagioDto);
            await _supervisorEstagioRepositorio.Adicionar(supervisorEstagio);
            supervisorEstagioDto.idSupervisor = supervisorEstagio.idSupervisor;
        }
        public async Task Adicionar(bool statusSupervisor)
        {
            var supervisorEstagio = new SupervisorEstagioModel() { statusSupervisor = statusSupervisor }; //mapeamento para converter a dto em model antes
            await _supervisorEstagioRepositorio.Adicionar(supervisorEstagio);
        }

        public async Task Atualizar(SupervisorEstagioDto supervisorEstagioDto)
        {
            var supervisorEstagio = _mapper.Map<SupervisorEstagioModel>(supervisorEstagioDto);
            await _supervisorEstagioRepositorio.Atualizar(supervisorEstagio);
        }

        public async Task Apagar(int id)
        {
            await _supervisorEstagioRepositorio.Apagar(id);
        }
    }
}
