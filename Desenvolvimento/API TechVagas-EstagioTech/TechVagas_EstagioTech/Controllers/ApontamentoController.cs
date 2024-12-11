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
    public class ApontamentoController : ControllerBase
    {
        private readonly IApontamentoService _apontamentoService;

        public ApontamentoController(IApontamentoService apontamentoService)
        {
            _apontamentoService = apontamentoService;
        }

        [HttpGet]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<IEnumerable<ApontamentoDto>>> Get()
        {
            var apontamentoDto = await _apontamentoService.BuscarApontamento();
            if (apontamentoDto == null) return NotFound("Apontamentos não encontrados!");
            return Ok(apontamentoDto);
        }

        [HttpGet("{id:int}", Name = "ObterApontamento")]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<ApontamentoDto>> Get(int id)
        {
            var apontamentoDto = await _apontamentoService.BuscarPoId(id);
            if (apontamentoDto == null) return NotFound("Apontamento não encontrado");
            return Ok(apontamentoDto);
        }

        [HttpPost]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult> Post([FromBody] ApontamentoDto apontamentoDto)
        {
            if (apontamentoDto is null) return BadRequest("Dado inválido!");
            await _apontamentoService.Adicionar(apontamentoDto);
            return Ok("Dado cadastrado com sucesso");
        }

        [HttpPut]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult> Put([FromBody] ApontamentoDto apontamentoDto)
        {
            if (apontamentoDto is null) return BadRequest("Dado invalido!");
            await _apontamentoService.Atualizar(apontamentoDto);
            return Ok(apontamentoDto);
        }

        [HttpDelete("{id:int}")]
        [Access(1, 3, 5, 6)]
        public async Task<ActionResult<ApontamentoDto>> Delete(int id)
        {
            var apontamentoDto = await _apontamentoService.BuscarPoId(id);
            if (apontamentoDto == null) return NotFound("Apontamento não econtrado!");
            await _apontamentoService.Apagar(id);
            return Ok(apontamentoDto);
        }
    }
}
