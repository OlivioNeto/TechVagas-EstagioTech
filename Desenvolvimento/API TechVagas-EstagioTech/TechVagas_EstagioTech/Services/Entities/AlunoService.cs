using AutoMapper;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios;
using TechVagas_EstagioTech.Repositorios.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Services.Entities
{
	public class AlunoService : IAlunoService
	{
		private readonly IAlunoRepositorio _alunoRepositorio;
		private readonly IMapper _mapper;

		public AlunoService(IAlunoRepositorio alunoRepositorio, IMapper mapper)
		{
			_alunoRepositorio = alunoRepositorio;
			_mapper = mapper;
		}

		public async Task<AlunoDto> BuscarPorId(int id)
		{
			var aluno = await _alunoRepositorio.BuscarPorId(id);
			return _mapper.Map<AlunoDto>(aluno);
		}

		public async Task<IEnumerable<AlunoDto>> BuscarTodosAlunos()
		{
			var aluno = await _alunoRepositorio.BuscarTodosAlunos();
			return _mapper.Map<IEnumerable<AlunoDto>>(aluno);
		}

		public async Task Adicionar(AlunoDto alunoDto)
		{
			var aluno = _mapper.Map<AlunoModel>(alunoDto);
			await _alunoRepositorio.Adicionar(aluno);
			alunoDto.AlunoId = aluno.AlunoId;
		}

		public async Task Atualizar(AlunoDto alunoDto)
		{
			var aluno = _mapper.Map<AlunoModel>(alunoDto);
			await _alunoRepositorio.Atualizar(aluno);
		}

		public async Task Apagar(int id)
		{
			await _alunoRepositorio.Apagar(id);
		}
	}

}
