using System;
using System.Collections.Generic;

namespace KadabraMVC.Models
{
    public partial class Pago
    {
        public int IdPago { get; set; }
        public int IdAdministrativo { get; set; }
        public int IdAlumno { get; set; }
        public string? MesPagado { get; set; }
        public DateTime? FyHRegistro { get; set; }
        public int CantidadMesesPagados { get; set; }

        public virtual Usuario IdAdministrativoNavigation { get; set; } = null!;
        public virtual Usuario IdAlumnoNavigation { get; set; } = null!;
    }
}
