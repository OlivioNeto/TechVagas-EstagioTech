﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TechVagas_EstagioTech.Objects.Model.Entities
{
    [Table("cargo")]
    public class CargoModel
    {
        [Column("cargoid")]
        public int CargoId { get; set; }

        [Column("descricao")]
        public string? Descricao { get; set; }

        [Column("tipo")]
        public string? Tipo { get; set; }

    }
}
