using System;
using System.Collections.Generic;

namespace KadabraMVC.Models
{
    public partial class RegistroDeClase
    {
        public int IdRegistroDeClase { get; set; }
        public int IdAdministrativo { get; set; }
        public int IdClase { get; set; }
        public DateTime? FyHRegistro { get; set; }

        public virtual Usuario IdAdministrativoNavigation { get; set; } = null!;
        public virtual Clase IdClaseNavigation { get; set; } = null!;
    }
}
