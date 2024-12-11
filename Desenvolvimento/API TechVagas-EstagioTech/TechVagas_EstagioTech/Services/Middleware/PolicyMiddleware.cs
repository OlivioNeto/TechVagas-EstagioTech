using Newtonsoft.Json;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace TechVagas_EstagioTech.Services.Middleware
{
    public class PolicyMiddleware
    {
        private readonly RequestDelegate _next;

        public PolicyMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Verifica se o UserType está no contexto
            if (context.Items.ContainsKey("UserType"))
            {
                var userType = (int)context.Items["UserType"];

                // Obtém o endpoint atual
                var endpoint = context.GetEndpoint();
                Console.WriteLine($"Endpoint: {endpoint?.DisplayName}");

                if (endpoint != null)
                {
                    // Verifica se o método tem o atributo AccessAttribute
                    var accessAttribute = endpoint.Metadata.GetMetadata<AccessAttribute>();

                    if (accessAttribute != null)
                    {
                        Console.WriteLine($"AccessAttribute Values: {string.Join(", ", accessAttribute.Values)}");
                        Console.WriteLine($"UserType: {userType}");

                        // Verifica se o userType está nos valores permitidos
                        if (!accessAttribute.Values.Contains(userType))
                        {
                            // Se o userType não está nos valores permitidos, bloqueia a requisição
                            await RespondWithForbidden(context);
                            return;
                        }
                    }
                }
            }

            // Se tudo estiver certo, continua a requisição normalmente
            await _next(context);
        }

        private static async Task RespondWithForbidden(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new { Message = "Forbidden" }));
        }
    }

    public static class PolicyMiddlewareExtensions
    {
        public static IApplicationBuilder UsePolicyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PolicyMiddleware>();
        }
    }
}
