using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoEstagioController : ControllerBase
    {
        private readonly IContratoEstagioService _contratoestagioService;

        public ContratoEstagioController(IContratoEstagioService contratoestagioService)
        {
            _contratoestagioService = contratoestagioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContratoEstagioDto>>> Get()
        {
            var contratoestagioDto = await _contratoestagioService.BuscarTodosContratoEstagios();
            if (contratoestagioDto == null) return NotFound("ContratoEstagios não encontradas!");
            return Ok(contratoestagioDto);
        }

        [HttpGet("{id:int}", Name = "ObterContratoEstagio")]
        public async Task<ActionResult<ContratoEstagioDto>> Get(int id)
        {
            var contratoestagioDto = await _contratoestagioService.BuscarPorId(id);
            if (contratoestagioDto == null) return NotFound("ContratoEstagio não encontrado");
            return Ok(contratoestagioDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ContratoEstagioDto contratoestagioDto)
        {
            if (contratoestagioDto is null) return BadRequest("Dados inválidos!");
            await _contratoestagioService.Adicionar(contratoestagioDto);
            return new CreatedAtRouteResult("ObterContratoEstagio", new { id = contratoestagioDto.contratoestagioId }, contratoestagioDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromBody] ContratoEstagioDto contratoestagioDto)
        {
            if (contratoestagioDto is null) return BadRequest("Dados invalidos!");
            await _contratoestagioService.Atualizar(contratoestagioDto);
            return Ok(contratoestagioDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ContratoEstagioDto>> Delete(int id)
        {
            var contratoestagioDto = await _contratoestagioService.BuscarPorId(id);
            if (contratoestagioDto == null) return NotFound("ContratoEstagio não econtrado!");
            await _contratoestagioService.Apagar(id);
            return Ok(contratoestagioDto);
        }
    }
}
