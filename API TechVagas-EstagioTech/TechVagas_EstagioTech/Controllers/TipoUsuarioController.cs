using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioService _service;

        public TipoUsuarioController(ITipoUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoUsuarioDto>>> Get()
        {
            var tipoUsuarioDTO = await _service.BuscarTodosTipoUsuario();
            if (tipoUsuarioDTO == null) return NotFound("Tipos de usuário não encontrados!");
            return Ok(tipoUsuarioDTO);
        }

        [HttpGet("{id}", Name = "GetTipoUsuario")]
        public async Task<ActionResult<TipoUsuarioDto>> Get(int id)
        {
            var tipoUsuarioDTO = await _service.BuscarPorId(id);
            if (tipoUsuarioDTO == null) return NotFound("Tipo de usuário não encontrado!");
            return Ok(tipoUsuarioDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar([FromBody] TipoUsuarioDto tipoUsuarioDto)
        {
            if (tipoUsuarioDto is null) return BadRequest("Dado inválido!");
            await _service.Adicionar(tipoUsuarioDto);
            return new CreatedAtRouteResult("GetTipoUsuario", new { id = tipoUsuarioDto.tipoUsuarioId }, tipoUsuarioDto);
        }

        [HttpPut()]
        public async Task<ActionResult> Atualizar([FromBody] TipoUsuarioDto tipoUsuarioDto)
        {
            if (tipoUsuarioDto is null) return BadRequest("Dado inválido!");
            await _service.Atualizar(tipoUsuarioDto);
            return Ok(tipoUsuarioDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoUsuarioDto>> Apagar(int id)
        {
            var tipoUsuarioDTO = await _service.BuscarPorId(id);
            if (tipoUsuarioDTO == null) return NotFound("Tipo de usuário não encontrado!");
            await _service.Apagar(id);
            return Ok(tipoUsuarioDTO);
        }
    }
}
