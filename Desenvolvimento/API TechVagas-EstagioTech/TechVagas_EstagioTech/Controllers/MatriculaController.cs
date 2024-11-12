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
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _matriculaService;

        public MatriculaController(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        [HttpGet]
        [Access(1)]
        public async Task<ActionResult<IEnumerable<MatriculaDto>>> Get()
        {
            var matriculaDto = await _matriculaService.BuscarTodasMatriculas();
            if (matriculaDto == null) return NotFound("Matriculas não encontradas!");
            return Ok(matriculaDto);
        }

        [HttpGet("{id:int}", Name = "ObterMatricula")]
        [Access(1)]
        public async Task<ActionResult<MatriculaDto>> Get(int id)
        {
            var matriculaDto = await _matriculaService.BuscarPorId(id);
            if (matriculaDto == null) return NotFound("Matricula não encontrada");
            return Ok(matriculaDto);
        }

        [HttpPost]
        [Access(1)]
        public async Task<ActionResult> Post([FromBody] MatriculaDto matriculaDto)
        {
            // SUPOMOS QUE EU TENHA O TOKEN NO HEADER, COMO EU PEGO ESSE TOKEN: HEADER -> AUTHORIZANTION -> BEARER
            if (matriculaDto is null) return BadRequest("Dado inválido!");
            await _matriculaService.Adicionar(matriculaDto);
            return new CreatedAtRouteResult("ObterMatricula", new { id = matriculaDto.MatriculaId }, matriculaDto);
        }

        [HttpPut("{id:int}")]
        [Access(1)]
        public async Task<ActionResult> Put([FromBody] MatriculaDto matriculaDto)
        {
            if (matriculaDto is null) return BadRequest("Dado invalido!");
            await _matriculaService.Atualizar(matriculaDto);
            return Ok(matriculaDto);
        }

        [HttpDelete("{id:int}")]
        [Access(1)]
        public async Task<ActionResult<MatriculaDto>> Delete(int id)
        {
            var matriculaDto = await _matriculaService.BuscarPorId(id);
            if (matriculaDto == null) return NotFound("Matriculas não econtradas!");
            await _matriculaService.Apagar(id);
            return Ok(matriculaDto);
        }
    }
}
