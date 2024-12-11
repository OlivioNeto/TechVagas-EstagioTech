using Jose;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TechVagas_EstagioTech.Model.Entities;
using TechVagas_EstagioTech.Objects.Utilities;

namespace TechVagas_EstagioTech.Dtos.Entities
{
    public class SessaoDto
    {
        public int SessaoId { get; set; }

        [Required(ErrorMessage = "A dade e hora de abertura é requerida!")]
        public string DataHoraInicio { get; set; }

        public string? DataHoraEncerramento { get; set; }

        public string TokenSessao { get; set; }

        [Required(ErrorMessage = "O status é requerido!")]
        public bool StatusSessao { get; set; }

        public string EmailPessoa { get; set; }

        public string NivelAcesso { get; set; }

        public UsuarioModel? UsuarioModel { get; set; }

        [ForeignKey("usuarioid")]
        public int UsuarioId { get; set; }

        public string GenerateToken()
        {
            SecurityEntity securityEntity = new();

            var payload = new Dictionary<string, object>
            {
                { "iss", securityEntity.Issuer },
                { "aud", securityEntity.Audience },
                { "sub", this.EmailPessoa },
                { "exp", DateTimeOffset.UtcNow.AddMinutes(60).ToUnixTimeSeconds() }
            };

            this.TokenSessao = JWT.Encode(payload, Encoding.UTF8.GetBytes(securityEntity.Key), JwsAlgorithm.HS256);

            return this.TokenSessao;
        }
        public bool ValidateToken()
        {
            SecurityEntity securityEntity = new();

            // Passo 1: Verificar se o token tem três partes
            string[] tokenParts = this.TokenSessao.Split('.');
            if (tokenParts.Length != 3)
            {
                return false;
            }

            try
            {
                // Passo 2: Decodificar o token
                string decodedToken = Encoding.UTF8.GetString(Base64Url.Decode(tokenParts[1]));

                // Passo 3: Verificar iss, aud e sub
                var payload = JsonConvert.DeserializeObject<Dictionary<string, object>>(decodedToken);
                if (!payload.TryGetValue("iss", out object issuerClaim) ||
                    !payload.TryGetValue("aud", out object audienceClaim) ||
                    !payload.TryGetValue("sub", out object subjectClaim))
                {
                    return false;
                }

                if (issuerClaim.ToString() != securityEntity.Issuer || audienceClaim.ToString() != securityEntity.Audience || subjectClaim.ToString() != this.EmailPessoa)
                {
                    return false;
                }

                // Passo 4: Verificar se o tempo expirou
                if (payload.TryGetValue("exp", out object expirationClaim))
                {
                    long expirationTime = long.Parse(expirationClaim.ToString());
                    var expirationDateTime = DateTimeOffset.FromUnixTimeSeconds(expirationTime).UtcDateTime;
                    if (expirationDateTime < DateTime.UtcNow)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                // Passo 5: Se tudo estiver certo
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}