using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Services.Entities;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> BuscarTodosUsuarios()
        {
            var usuariosDTO = await _usuarioService.BuscarTodosUsuarios();
            if (usuariosDTO == null) return NotFound("Usuarios não encontradas!");
            return Ok(usuariosDTO);
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public async Task<ActionResult<UsuarioDto>> BuscarPorId(int id)
        {
            var usuarioDTO = await _usuarioService.BuscarPorId(id);
            if (usuarioDTO == null) return NotFound("Usuario não encontradas!");
            return Ok(usuarioDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar([FromBody] UsuarioDto usuarioDto)
        {
            if (usuarioDto is null) return BadRequest("Dado inválido!");
            var usuariosDTO = await _usuarioService.BuscarPorEmail(usuarioDto.EmailUsuario);
            foreach (var usuario in usuariosDTO)
            {
                if (usuario.EmailUsuario.ToUpper() == usuarioDto.EmailUsuario.ToUpper())
                {
                    return NotFound("O e-mail informado já existe!");
                }
            }
            if (usuarioDto.EmailUsuario == "devproduction@gmail.com") NotFound("O e-mail informado já existe!");

            await _usuarioService.Adicionar(usuarioDto);
            return new CreatedAtRouteResult("GetUsuario", new { id = usuarioDto.usuarioId }, usuarioDto);
        }

        [HttpPut()]
        public async Task<ActionResult> Atualizar([FromBody] UsuarioDto usuarioDto)
        {
            if (usuarioDto is null) return BadRequest("Dado inválido!");

            var dadoAnterior = await _usuarioService.BuscarPorId(usuarioDto.usuarioId);
            if (dadoAnterior == null) return NotFound("Usuário não encontrado!");
            if (dadoAnterior.EmailUsuario.ToUpper() != usuarioDto.EmailUsuario.ToUpper())
            {
                var usuariosDTO = await _usuarioService.BuscarPorEmail(usuarioDto.EmailUsuario);
                foreach (var usuario in usuariosDTO)
                {
                    if (usuario.EmailUsuario.ToUpper() == usuarioDto.EmailUsuario.ToUpper())
                    {
                        return NotFound("O e-mail informado já existe!");
                    }
                }
                if (usuarioDto.EmailUsuario == "devproduction@gmail.com") return NotFound("O e-mail informado já existe!");
            }

            await _usuarioService.Atualizar(usuarioDto);
            return Ok(usuarioDto);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioDto>> Delete(int id)
        {
            var usuarioDTO = await _usuarioService.BuscarPorId(id);
            if (usuarioDTO == null) return NotFound("Usuario não encontrada!");
            await _usuarioService.Apagar(id);
            return Ok(usuarioDTO);
        }
    }

}
