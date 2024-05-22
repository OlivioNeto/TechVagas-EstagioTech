using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TechVagas_EstagioTech.Data;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService, DBContext context)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> Get()
        {
            var usuariosDto = await _usuarioService.BuscarTodosUsuarios();
            return Ok(usuariosDto);
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public async Task<ActionResult<UsuarioDto>> Get(int id)
        {
            var usuarioDto = await _usuarioService.BuscarPorId(id);
            if (usuarioDto == null) return NotFound("Usuario não encontradas!");
            return Ok(usuarioDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioDto usuarioDto)
        {
            if (usuarioDto is null) return BadRequest("Dado(s) inválido(s)!");
            usuarioDto.Email = usuarioDto.Email.ToLower();

            var usuariosDTO = await _usuarioService.BuscarTodosUsuarios();

            string email = "";
            string cpfcnpj = "";

            if (usuariosDTO is not null)
            {
                string existCpfCnpj = "";

                foreach (var usuario in usuariosDTO)
                {
                    if (usuarioDto.Email == usuario.Email) email = "O e-mail informado já existe!";

                    if (usuarioDto.CpfCnpj == usuario.CpfCnpj)
                    {
                        if (usuarioDto.CpfCnpj.Length == 14) existCpfCnpj = "O CPF informado já existe!";
                        else existCpfCnpj = "O CNPJ informado já existe!";
                    };
                }

                if (cpfcnpj == "") cpfcnpj = existCpfCnpj;
            }

            if (usuarioDto.Email == "techvdev@development.com") email = "O e-mail informado já existe!";

            if (email == "" && cpfcnpj == "")
            {
                await _usuarioService.Adicionar(usuarioDto);
                return new CreatedAtRouteResult("GetUsuario", new { id = usuarioDto.UsuarioId }, usuarioDto);
            }

            return BadRequest(new { email, cpfcnpj, });
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] UsuarioDto usuarioDto)
        {
            if (usuarioDto.UsuarioId == 1) return BadRequest("Dado(s) inválido(s)!");
            if (usuarioDto is null) return BadRequest("Dado(s) inválido(s)!");
            usuarioDto.Email = usuarioDto.Email.ToLower();

            var usuariosDTO = await _usuarioService.BuscarTodosUsuarios();
            usuariosDTO = usuariosDTO.Where(u => u.UsuarioId != usuarioDto.UsuarioId);

            string email = "";
            string cpfcnpj = "";

            if (usuariosDTO is not null)
            {
                string existCpfCnpj = "";

                foreach (var usuario in usuariosDTO)
                {
                    if (usuarioDto.Email == usuario.Email) email = "O e-mail informado já existe!";

                    if (usuarioDto.CpfCnpj == usuario.CpfCnpj)
                    {
                        if (usuarioDto.CpfCnpj.Length == 14) existCpfCnpj = "O CPF informado já existe!";
                        else existCpfCnpj = "O CNPJ informado já existe!";
                    };
                }

                if (cpfcnpj == "") cpfcnpj = existCpfCnpj;
            }

            if (usuarioDto.Email == "techvdev@development.com") email = "O e-mail informado já existe!";

            if (email == "" && cpfcnpj == "")
            {
                await _usuarioService.Atualizar(usuarioDto);
                return Ok(usuarioDto);
            }

            return BadRequest(new { email, cpfcnpj });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioDto>> Apagar(int id)
        {
            if (id == 1) return NotFound("Usuário não encontrado!");

            var usuarioDto = await _usuarioService.BuscarPorId(id);
            if (usuarioDto == null) return NotFound("Usuário não encontrado!");
            await _usuarioService.Apagar(id);
            return Ok(usuarioDto);
        }
    }
}
