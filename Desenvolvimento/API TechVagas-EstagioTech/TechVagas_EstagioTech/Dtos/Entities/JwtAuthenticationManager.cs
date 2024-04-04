using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    public class JwtAuthenticationManager
    {
        private readonly string _secret;
        private readonly Dictionary<string, UserType> _userRoles;

        public JwtAuthenticationManager(string secret)
        {
            _secret = secret;
            _userRoles = new Dictionary<string, UserType>
        {
            // Aqui você pode adicionar os usuários e seus tipos
            {"admin", UserType.Administrador},
            {"aluno", UserType.Aluno},
            {"coordenador", UserType.Coordenador},
            {"empresa", UserType.Empresa}
        };
        }

        public string Authenticate(string username, string password)
        {
            // Simulação de autenticação
            if (!(username == "admin" && password == "admin") &&
                !(username == "aluno" && password == "aluno") &&
                !(username == "coordenador" && password == "coordenador") &&
                !(username == "empresa" && password == "empresa"))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, _userRoles[username].ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public UserType? GetRole(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var username = jwtToken.Claims.First(x => x.Type == ClaimTypes.Name).Value;

                return _userRoles.GetValueOrDefault(username);
            }
            catch
            {
                return null;
            }
        }
    }
}
