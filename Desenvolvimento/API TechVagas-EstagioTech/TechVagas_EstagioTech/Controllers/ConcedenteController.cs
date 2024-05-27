using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Objects.Dtos.Entities;
using TechVagas_EstagioTech.Services.Entities;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcedenteController : ControllerBase
    {
        private readonly IConcedenteService _concedenteService;

        public ConcedenteController(IConcedenteService concedenteService)
        {
            _concedenteService = concedenteService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ConcedenteDto>>> Get()
        {
            var concedenteDto = await _concedenteService.BuscarTodosConcedentes();
            if (concedenteDto == null) return NotFound("Concedentes não encontradas!");
            return Ok(concedenteDto);
        }

        [HttpGet("{id:int}", Name = "ObterConcedente")]
        public async Task<ActionResult<ConcedenteDto>> Get(int id)
        {
            var concedenteDto = await _concedenteService.BuscarPorId(id);
            if (concedenteDto == null) return NotFound("Concedente não encontrado");
            return Ok(concedenteDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ConcedenteDto concedenteDto)
        {
            if (concedenteDto is null) return BadRequest("Dado inválido!");
            await _concedenteService.Adicionar(concedenteDto);
            return new CreatedAtRouteResult("ObterConcedente", new { id = concedenteDto.concedenteId }, concedenteDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromBody] ConcedenteDto concedenteDto)
        {
            if (concedenteDto is null) return BadRequest("Dado invalido!");
            await _concedenteService.Atualizar(concedenteDto);
            return Ok(concedenteDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ConcedenteDto>> Delete(int id)
        {
            var concedenteDto = await _concedenteService.BuscarPorId(id);
            if (concedenteDto == null) return NotFound("Concedente não econtrada!");
            await _concedenteService.Apagar(id);
            return Ok(concedenteDto);
        }
    }
}
