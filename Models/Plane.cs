using System;
using System.Collections.Generic;

namespace KadabraMVC.Models
{
    public partial class Plane
    {
        public int IdPlan { get; set; }
        public string NombrePlan { get; set; } = null!;
        public decimal? PrecioMensual { get; set; }
    }
}
