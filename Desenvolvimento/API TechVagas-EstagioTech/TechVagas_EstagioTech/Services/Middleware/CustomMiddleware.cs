using Newtonsoft.Json;
using System.Net;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace TechVagas_EstagioTech.Services.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public CustomMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
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

                    // Verifique se o cabeçalho contém o token
                    if (tokenParts.Length == 2 && tokenParts[0] == "Bearer")
                    {
                        var tokenValue = tokenParts[1];

                        // Verifique a sessão associada com o token
                        var sessao = await _sessaoRepositorio.GetByToken(tokenValue);

                        if (sessao == null || !sessao.StatusSessao || !sessao.ValidateToken())
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(new { Message = "Unauthorized" }));
                            return;
                        }

                        var user = await _usuarioRepositorio.BuscarPorId(sessao.UsuarioId);

                        if (user != null)
                        {
                            var userPolicy = user.UserType.ToString() + "Policy"; // Converte enum para string

                            // Aqui você deve definir quais políticas são necessárias. Supondo que seja um cabeçalho.
                            var requiredPolicies = context.Request.Headers["X-Required-Policies"].ToString().Split(',').ToList();

                            if (!requiredPolicies.Any(policy => policy.Equals(userPolicy, StringComparison.OrdinalIgnoreCase)))
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { Message = "Unauthorized" }));
                                return;
                            }
                        }
                        else
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(new { Message = "Unauthorized" }));
                            return;
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new { Message = "Unauthorized" }));
                        return;
                    }
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(new { Message = "Unauthorized" }));
                    return;
                }
            }

            await _next(context);
        }
    }

    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
