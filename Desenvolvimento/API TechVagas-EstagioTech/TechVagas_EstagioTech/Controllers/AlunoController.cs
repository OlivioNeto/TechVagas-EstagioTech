using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Services.Entities;
using TechVagas_EstagioTech.Services.Interfaces;
using TechVagas_EstagioTech.Services.Middleware;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class AlunoController : ControllerBase
	{
		private readonly IAlunoService _alunoService;

		public AlunoController(IAlunoService alunoService)
		{
			_alunoService = alunoService;
		}

		[HttpGet]
		[Access(1, 2)]
		public async Task<ActionResult<IEnumerable<AlunoDto>>> Get()
		{
			var alunoDto = await _alunoService.BuscarTodosAlunos();
			if (alunoDto == null) return NotFound("Alunos não encontradas!");
			return Ok(alunoDto);
		}

		[HttpGet("{id:int}", Name = "ObterAluno")]
        [Access(1, 2, 4)]
        public async Task<ActionResult<AlunoDto>> Get(int id)
		{
			var alunoDto = await _alunoService.BuscarPorId(id);
			if (alunoDto == null) return NotFound("Aluno não encontrado");
			return Ok(alunoDto);
		}

        
        [HttpPost]
        [Access(1, 2)]
        public async Task<ActionResult> Post([FromBody] AlunoDto alunoDto)
		{
			if (alunoDto is null) return BadRequest("Dado inválido!");
			await _alunoService.Adicionar(alunoDto);
			return new CreatedAtRouteResult("ObterAluno", new { id = alunoDto.AlunoId }, alunoDto);
		}

		[HttpPut("{id:int}")]
        [Access(1, 2)]
        public async Task<ActionResult> Put([FromBody] AlunoDto alunoDto)
		{
			if (alunoDto is null) return BadRequest("Dado invalido!");
			await _alunoService.Atualizar(alunoDto);
			return Ok(alunoDto);
		}

		[HttpDelete("{id:int}")]
        [Access(1, 2)]
        public async Task<ActionResult<AlunoDto>> Delete(int id)
		{
			var alunoDto = await _alunoService.BuscarPorId(id);
			if (alunoDto == null) return NotFound("Aluno não encontrado!");
			await _alunoService.Apagar(id);
			return Ok(alunoDto);
		}
	}
}
