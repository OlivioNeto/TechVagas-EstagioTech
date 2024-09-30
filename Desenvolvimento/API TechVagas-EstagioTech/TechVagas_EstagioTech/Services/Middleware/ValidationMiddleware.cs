using Newtonsoft.Json;
using System.Net;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace TechVagas_EstagioTech.Services.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ValidationMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var _sessaoRepositorio = scope.ServiceProvider.GetRequiredService<ISessaoRepositorio>();
                var _usuarioRepositorio = scope.ServiceProvider.GetRequiredService<IUsuarioRepositorio>();

                if (context.Request.Headers.TryGetValue("Authorization", out var authHeader))
                {
                    var tokenParts = authHeader.ToString().Split(' ');

                    if (tokenParts.Length == 2 && tokenParts[0] == "Bearer")
                    {
                        var tokenValue = tokenParts[1];

                        var sessao = await _sessaoRepositorio.GetByToken(tokenValue);

                        if (sessao == null || !sessao.StatusSessao || !sessao.ValidateToken())
                        {
                            await RespondWithUnauthorized(context);
                            return;
                        }

                        var user = await _usuarioRepositorio.BuscarPorId(sessao.UsuarioId);

                        if (user == null)
                        {
                            await RespondWithUnauthorized(context);
                            return;
                        }

                        context.Items["UserType"] = user.UserType;
                    }
                    else
                    {
                        await RespondWithUnauthorized(context);
                        return;
                    }
                }
                else
                {
                    await RespondWithUnauthorized(context);
                    return;
                }
            }

            await _next(context);
        }

        private static async Task RespondWithUnauthorized(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new { Message = "Unauthorized" }));
        }
    }

    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ValidationMiddleware>();
        }
    }
}
