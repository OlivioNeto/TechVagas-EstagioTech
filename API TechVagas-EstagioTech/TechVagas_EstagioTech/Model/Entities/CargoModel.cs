namespace TechVagas_EstagioTech.Model.Entities
{
    public class CargoModel
    {
        public int CargoId { get; set; }
        public string? Descricao { get; set; }
        public string? Tipo { get; set; }

        public VagasModel? VagasModel { get; set; }
    }
}
