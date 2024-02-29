using AutoMapper;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Services.Entities
{
    public class InstituicaoEnsinoService : IInstituicaoEnsinoService
    {
        private readonly IInstituicaoEnsinoService _instituicaoEnsinoRepositorio;
        private readonly IMapper _mapper;

        public InstituicaoEnsinoService(IInstituicaoEnsinoService instituicaoEnsinoRepositorio, IMapper mapper)
        {
            _instituicaoEnsinoRepositorio = instituicaoEnsinoRepositorio;
            _mapper = mapper;
        }
        public async Task<InstituicaoEnsinoDto> BuscarPorId(int id)
        {
            var instituicao = await _instituicaoEnsinoRepositorio.BuscarPorId(id);
            return _mapper.Map<InstituicaoEnsinoDto>(instituicao);
        }

        public async Task<IEnumerable<InstituicaoEnsinoDto>> BuscarTodasInstituicoes()
        {
            var instituicao = await _instituicaoEnsinoRepositorio.BuscarTodasInstituicoes();
            return _mapper.Map<IEnumerable<InstituicaoEnsinoDto>>(instituicao);
        }

        public async Task Adicionar(InstituicaoEnsinoDto instituicaoEnsinoDto)
        {
            var instituicao = _mapper.Map<InstituicaoEnsinoModel>(instituicaoEnsinoDto);
            await _instituicaoEnsinoRepositorio.Adicionar(instituicaoEnsinoDto);
            instituicaoEnsinoDto.Id = instituicao.Id;
        }

        public async Task Atualizar(InstituicaoEnsinoDto instituicaoEnsinoDto)
        {
            var instituicao = _mapper.Map<InstituicaoEnsinoModel>(instituicaoEnsinoDto);
            await _instituicaoEnsinoRepositorio.Atualizar(instituicaoEnsinoDto);
        }

        public async Task Apagar(int id)
        {
            await _instituicaoEnsinoRepositorio.Apagar(id);
        }
    }
}
