using AutoMapper;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Repositorios;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Services.Entities
{
    public class ConcedenteService : IConcedenteService
    {
        private readonly IConcedenteRepositorio _concedenteRepositorio;
        private readonly IMapper _mapper;

        public ConcedenteService(IConcedenteRepositorio concedenteRepositorio, IMapper mapper)
        {
            _concedenteRepositorio = concedenteRepositorio;
            _mapper = mapper;
        }

        public async Task<ConcedenteDto> BuscarPorId(int id)
        {
            var concedente = await _concedenteRepositorio.BuscarPorId(id);
            return _mapper.Map<ConcedenteDto>(concedente);
        }

        public async Task<IEnumerable<ConcedenteDto>> BuscarTodosConcedentes()
        {
            var concedente = await _concedenteRepositorio.BuscarTodosConcedentes();
            return _mapper.Map<IEnumerable<ConcedenteDto>>(concedente);
        }

        public async Task Adicionar(ConcedenteDto concedenteDto)
        {
            var concedente = _mapper.Map<ConcedenteModel>(concedenteDto);
            await _concedenteRepositorio.Adicionar(concedente);
            concedenteDto.concedenteId = concedente.concedenteId;
        }

        public async Task Atualizar(ConcedenteDto concedenteDto)
        {
            var concedente = _mapper.Map<ConcedenteModel>(concedenteDto);
            await _concedenteRepositorio.Atualizar(concedente);
        }

        public async Task Apagar(int id)
        {
            await _concedenteRepositorio.Apagar(id);
        }
    }   
}
