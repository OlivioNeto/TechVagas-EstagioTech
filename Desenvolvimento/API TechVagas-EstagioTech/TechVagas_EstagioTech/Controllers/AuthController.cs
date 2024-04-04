using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechVagas_EstagioTech.Dtos.Entities;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtAuthenticationManager _jwtAuthenticationManager;

        public AuthController(JwtAuthenticationManager jwtAuthenticationManager)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UsuarioDto usuarioDto)
        {
            var token = _jwtAuthenticationManager.Authenticate(usuarioDto.Nome, usuarioDto.Senha);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { Token = token });
        }
    }

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly JwtAuthenticationManager _jwtAuthenticationManager;

        public UsersController(JwtAuthenticationManager jwtAuthenticationManager)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpGet("special-action")]
        [Authorize(Roles = "Administrador")]
        public IActionResult SpecialAction()
        {
            // Ação especial que somente o administrador pode acessar
            return Ok("Ação especial realizada com sucesso!");
        }
    }
}
