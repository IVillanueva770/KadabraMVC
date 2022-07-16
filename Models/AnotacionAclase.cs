using System;
using System.Collections.Generic;

namespace KadabraMVC.Models
{
    public partial class AnotacionAclase
    {
        public int IdAnotacionAclase { get; set; }
        public int IdClase { get; set; }
        public int IdAlumno { get; set; }
        public DateTime? FyHRegistro { get; set; }
        public string? Estado { get; set; }

        public virtual Usuario IdAlumnoNavigation { get; set; } = null!;
        public virtual Clase IdClaseNavigation { get; set; } = null!;
    }
}
