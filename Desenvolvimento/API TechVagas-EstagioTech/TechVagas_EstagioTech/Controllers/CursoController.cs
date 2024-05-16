using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Objects.Model.Entities;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using TechVagas_EstagioTech.Services.Entities;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
		private readonly ICursoService _cursoService;

		public CursoController(ICursoService cursoService)
		{
			_cursoService = cursoService;
		}


		[HttpGet]
		public async Task<ActionResult<IEnumerable<CursoDto>>> Get()
		{
			var cursoDto = await _cursoService.BuscarTodosCursos();
			if (cursoDto == null) return NotFound("Cursos não encontradas!");
			return Ok(cursoDto);
		}

		[HttpGet("{id:int}", Name = "ObterCurso")]
		public async Task<ActionResult<CursoDto>> Get(int id)
		{
			var cursoDto = await _cursoService.BuscarPorId(id);
			if (cursoDto == null) return NotFound("Curso não encontrado");
			return Ok(cursoDto);
		}

		[HttpPost]
		public async Task<ActionResult> Post([FromBody] CursoDto cursoDto)
		{
			if (cursoDto is null) return BadRequest("Dado inválido!");
			await _cursoService.Adicionar(cursoDto);
			return new CreatedAtRouteResult("ObterCurso", new { id = cursoDto.cursoid }, cursoDto);
		}


		[HttpPut("{id:int}")]
		public async Task<ActionResult> Put([FromBody] CursoDto cursoDto)
		{
			if (cursoDto is null) return BadRequest("Dado invalido!");
			await _cursoService.Atualizar(cursoDto);
			return Ok(cursoDto);
		}

		[HttpDelete("{id:int}")]
		public async Task<ActionResult<CursoDto>> Delete(int id)
		{
			var cursoDto = await _cursoService.BuscarPorId(id);
			if (cursoDto == null) return NotFound("Curso não econtrado!");
			await _cursoService.Apagar(id);
			return Ok(cursoDto);
		}
	}
}
