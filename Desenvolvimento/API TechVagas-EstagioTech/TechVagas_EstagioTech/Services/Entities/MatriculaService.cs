using AutoMapper;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Repositorios;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Services.Entities
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepositorio _matriculaRepositorio;
        private readonly IMapper _mapper;

        public MatriculaService(IMatriculaRepositorio matriculaRepositorio, IMapper mapper)
        {
            _matriculaRepositorio = matriculaRepositorio;
            _mapper = mapper;
        }
        public async Task<MatriculaDto> BuscarPorAluno(int idAluno)
        {
            var matriculas = await _matriculaRepositorio.BuscarPorAluno(idAluno);
            return _mapper.Map<MatriculaDto>(matriculas);
        }
        public async Task<MatriculaDto> BuscarPorId(int id)
        {
            var matriculas = await _matriculaRepositorio.BuscarPorId(id);
            return _mapper.Map<MatriculaDto>(matriculas);
        }

        public async Task<IEnumerable<MatriculaDto>> BuscarTodasMatriculas()
        {
            var matriculas = await _matriculaRepositorio.BuscarTodasMatriculas();
            return _mapper.Map<IEnumerable<MatriculaDto>>(matriculas);
        }

        public async Task Adicionar(MatriculaDto matriculaDto)
        {
            var matriculas = _mapper.Map<MatriculaModel>(matriculaDto);
            await _matriculaRepositorio.Adicionar(matriculas);
            matriculaDto.MatriculaId = matriculas.MatriculaId;
        }

        public async Task Atualizar(MatriculaDto matriculaDto)
        {
            var matriculas = _mapper.Map<MatriculaModel>(matriculaDto);
            await _matriculaRepositorio.Atualizar(matriculas);
        }

        public async Task Apagar(int id)
        {
            await _matriculaRepositorio.Apagar(id);
        }
    }
}
