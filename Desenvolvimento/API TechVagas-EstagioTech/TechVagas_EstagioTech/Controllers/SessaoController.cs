using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Objects.Utilities;
using TechVagas_EstagioTech.Services.Interfaces;
using TechVagas_EstagioTech.Services.Middleware;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessaoController : ControllerBase
    {
        private readonly ISessaoService _sessaoService;
        private readonly IUsuarioService _usuarioService;

        public SessaoController(ISessaoService sessaoService, IUsuarioService usuarioService)
        {
            var userType = UserTypeModel.Administrador;
            _sessaoService = sessaoService;
            _usuarioService = usuarioService;
        }

        [HttpGet("GetOnlineUsers")]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetOnlineUsers()
        {
            var usuariosDto = await _sessaoService.GetOnlineUsers();
            return Ok(usuariosDto);
        }

        [HttpGet("GetOfflineUsers")]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetOfflineUsers()
        {
            var usuariosDto = await _sessaoService.GetOfflineUsers();
            return Ok(usuariosDto);
        }

        [HttpGet("GetSession")]
        public async Task<ActionResult<SessaoDto>> GetSession([FromQuery] TokenAcess token)
        {
            if (token is null) return BadRequest(new { status = false, response = "Dados inválidos!" });

            var sessaoDTO = await _sessaoService.GetByToken(token.Token);
            if (sessaoDTO is null) return Unauthorized(new { status = false, response = "Sessão não encontrada!" });
            else if (sessaoDTO.StatusSessao && sessaoDTO.ValidateToken())
            {
                return Ok(new { status = true, response = sessaoDTO });
            }
            else
            {
                sessaoDTO.StatusSessao = false;
                sessaoDTO.DataHoraEncerramento = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                await _sessaoService.Update(sessaoDTO);

                Response.Headers.Remove("Authorization");
                return Unauthorized(new { status = false, response = "Sessão expirada!" });
            }
        }
        [HttpGet("GetUser/{token}")]
        public async Task<ActionResult<UsuarioDto>> GetUser(string token)
        {
            if (token is null) return BadRequest(new { status = false, response = "Dados inválidos!" });

            var sessaoDTO = await _sessaoService.GetByToken(token);
            if (sessaoDTO is null) return Unauthorized(new { status = false, response = "Sessão não encontrada!" });
            else if (sessaoDTO.StatusSessao && sessaoDTO.ValidateToken())
            {
                var usuarioDTO = await _sessaoService.GetUser(token);

                return Ok(new { status = true, response = usuarioDTO });
            }
            else
            {
                sessaoDTO.StatusSessao = false;
                sessaoDTO.DataHoraEncerramento = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                await _sessaoService.Update(sessaoDTO);

                Response.Headers.Remove("Authorization");
                return Unauthorized(new { status = false, response = "Sessão expirada!" });
            }
        }
        [HttpPost("Autentication")]
        [Anonymous]
        public async Task<ActionResult> CreateSession([FromBody] LoginDto loginDto)
        {
            if (loginDto is null)
                return BadRequest(new { status = false, response = "Dados inválidos!" });

            var usuarioDTO = await _usuarioService.Login(loginDto);

            if (usuarioDTO is not null)
            {
                SessaoDto sessaoDTO = new()
                {
                    UsuarioId = usuarioDTO.UsuarioId,
                    DataHoraInicio = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                    StatusSessao = true,

                    EmailPessoa = usuarioDTO.Email,
                    NivelAcesso = usuarioDTO.UserType.ToString(),
                };
                sessaoDTO.GenerateToken();
                
                await _sessaoService.Create(sessaoDTO);
                return Ok(new { status = true, response = sessaoDTO.TokenSessao });
            }

            return Unauthorized(new { status = false, response = "E-mail ou senha incorretos!" });
        }

        [HttpPut("Validation")]
        public async Task<IActionResult> ValidateSession([FromBody] TokenAcess token)
        {
            var sessaoDTO = await _sessaoService.GetByToken(token.Token);
            if (sessaoDTO is null) return Unauthorized(new { status = false, response = "Sessão não encontrada!" });

            if (sessaoDTO.StatusSessao && sessaoDTO.ValidateToken())
            {
                sessaoDTO.GenerateToken();
                await _sessaoService.Update(sessaoDTO);

                return Ok(new { status = true, response = sessaoDTO.TokenSessao });
            }
            else
            {
                sessaoDTO.StatusSessao = false;
                sessaoDTO.DataHoraEncerramento = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                await _sessaoService.Update(sessaoDTO);

                Response.Headers.Remove("Authorization");
                return Unauthorized(new { status = false, response = "Sessão expirada!" });
            }
        }

        [HttpPut("Close")]
        public async Task<IActionResult> CloseSession([FromBody] TokenAcess token)
        {
            Response.Headers.Remove("Authorization");
            var sessaoDTO = await _sessaoService.GetByToken(token.Token);
            if (sessaoDTO is null) { Response.Headers.Remove("Authorization"); return Unauthorized(new { status = false, response = "Sessão não encontrada!" }); }

            sessaoDTO.StatusSessao = false;
            sessaoDTO.DataHoraEncerramento = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            await _sessaoService.Update(sessaoDTO);


            return Ok(new { status = true, response = "Sessão encerrada com sucesso!" });
        }

        [HttpPut("CloseUserSession")]
        public async Task<IActionResult> CloseUserSession(int id)
        {
            if (id == 1) return Ok(new { status = true, response = "Nenhuma sessão aberta encontrada!" });

            var sessoes = await _sessaoService.GetOpenSessionByUser(id);
            if (sessoes == null) return Ok(new { status = true, response = "Nenhuma sessão aberta encontrada!" });

            foreach (var sessao in sessoes)
            {
                sessao.StatusSessao = false;
                sessao.DataHoraEncerramento = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                await _sessaoService.Update(sessao);
            }

            return Ok(new { status = true, response = "Sessão do usuário encerrada!" });
        }


        [HttpGet("GetAllSessions")]
        public async Task<ActionResult<IEnumerable<SessaoDto>>> GetAllSessions()
        {
            var sessoesDTO = await _sessaoService.GetAll();
            return Ok(sessoesDTO);
        }

        [HttpGet("GetAllOpenSessions")]
        public async Task<ActionResult<IEnumerable<SessaoDto>>> GetAllOpenSessions()
        {
            var sessoesDTO = await _sessaoService.GetOpenSessions();
            return Ok(sessoesDTO);
        }

        [HttpGet("GetAllCloseSessions")]
        public async Task<ActionResult<IEnumerable<SessaoDto>>> GetAllCloseSessions()
        {
            var sessoesDTO = await _sessaoService.GetCloseSessions();
            return Ok(sessoesDTO);
        }

        //[HttpDelete("Delete")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var sessaoDTO = await _sessaoService.GetById(id);
        //    if (sessaoDTO is null || sessaoDTO.IdUsuario == 1) return Unauthorized(new { status = false, response = "Sessão não encontrada!" });
        //    await _sessaoService.Remove(id);
        //    return Ok(new { status = true, response = "Sessão removida com sucesso!" });
        //}

    }
}
