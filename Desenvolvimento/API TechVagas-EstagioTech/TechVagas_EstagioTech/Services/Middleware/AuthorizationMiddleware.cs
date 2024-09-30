using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;

namespace TechVagas_EstagioTech.Services.Middleware
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly string _jwtSecret;

        public AuthorizationMiddleware(RequestDelegate next, IUsuarioRepositorio usuarioRepositorio, string jwtSecret)
        {
            _next = next;
            _usuarioRepositorio = usuarioRepositorio;
            _jwtSecret = jwtSecret;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // 1. Extrair o token do cabeçalho
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Token não fornecido.");
                return;
            }

            // 2. Buscar o usuário a partir do token
            var user = await GetUserFromToken(token);
            if (user == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Usuário não encontrado.");
                return;
            }

            // 3. Obter as políticas (assinaturas) do método
            var endpoint = context.GetEndpoint();
            if (endpoint == null)
            {
                await _next(context);
                return;
            }

            var policies = endpoint.Metadata.OfType<PolicyAttribute>().Select(p => p.Policy).ToList();

            // 4. Verificar se o tipo do usuário está autorizado
            var userPolicy = user.UserType.ToString() + "Policy"; // Converte enum para string
            if (policies.Any(policy => policy.Equals(userPolicy, StringComparison.OrdinalIgnoreCase)))
            {
                await _next(context); // O usuário está autorizado, continue para o próximo middleware
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Acesso negado.");
            }
        }

        private async Task<UsuarioModel> GetUserFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);

            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };

                // Validar e Decodificar o Token
                var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
                var userIdString = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out var userId))
                    return null;

                // Buscar o usuário no repositório
                return await _usuarioRepositorio.BuscarPorId(userId);
            }
            catch
            {
                // Em caso de erro na validação do token
                return null;
            }
        }

        public class PolicyAttribute : Attribute
        {
            public string Policy { get; }

            public PolicyAttribute(string policy)
            {
                Policy = policy;
            }
        }

        public class User
        {
            public string Role { get; set; }
        }
    }
}
