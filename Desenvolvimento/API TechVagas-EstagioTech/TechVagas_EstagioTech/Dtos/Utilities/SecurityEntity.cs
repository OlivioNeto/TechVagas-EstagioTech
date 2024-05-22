namespace TechVagas_EstagioTech.Dtos.Utilities
{
    public class SecurityEntity
    {
        public string Issuer { get; } = "Server API";
        public string Audience { get; } = "WebSite";
        public string Key { get; } = "TechVagas_BarramentUser_API_Autentication";
    }
}
