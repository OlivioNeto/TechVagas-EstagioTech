namespace TechVagas_EstagioTech.Dtos.Entities
{
    public class EntitySecurity
    {
        public string Issuer { get; } = "TECHVAGAS_Client";
        public string Audience { get; } = "TECHVAGAS_Server";
        public string Key { get; } = "TECHVAGAS_System";
    }
}
