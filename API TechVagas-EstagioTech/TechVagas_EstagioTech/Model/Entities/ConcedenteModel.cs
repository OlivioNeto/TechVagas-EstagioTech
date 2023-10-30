using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Model.Entities
{
    [Table("concedente")]
    public class ConcedenteModel
    {
        [Column("concedenteid")]
        public int concedenteId { get; set; }


        [Column("razaosocial")]
        public string? RazaoSocial { get; set; }


        [Column("responsavelestagio")]
        public string? ResponsavelEstagio { get; set;}


        [Column("cnpj")]
        public string? Cnpj { get; set; }


        [Column("localidade")]
        public string? Localidade { get; set; }
    }
}
