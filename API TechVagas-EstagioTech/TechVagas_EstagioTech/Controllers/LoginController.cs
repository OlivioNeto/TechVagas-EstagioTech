using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechVagas_EstagioTech.Dtos.Entities;
using TechVagas_EstagioTech.Services.Interfaces;

namespace TechVagas_EstagioTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (loginDto is null) return BadRequest("Dado inválido!");
            var usuarioDTO = await _usuarioService.Login(loginDto);

            if (!(usuarioDTO is null))
            {
                if (loginDto.Email == usuarioDTO.EmailUsuario && loginDto.Senha == usuarioDTO.SenhaUsuario)
                {
                    string GenerateToken(string username)
                    {
                        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("E2F53C76E74237C824A47C7C4156510C818A7D4C98C8E9A3105C1C7D9240E5C3"));
                        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            issuer: "TechVagasEstagioTech",
                            audience: "WebSite",
                            claims: new[] { new Claim(ClaimTypes.Name, username) },
                            expires: DateTime.Now.AddHours(1),
                            signingCredentials: credentials
                        );

                        return new JwtSecurityTokenHandler().WriteToken(token);
                    }

                    var token = GenerateToken(usuarioDTO.NomeUsuario);
                    return Ok(new { token, usuario = usuarioDTO });
                }
            }

            return BadRequest("Credenciais inválidas!");
        }

    }
}


