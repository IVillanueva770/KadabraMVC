using System;
using System.Collections.Generic;

namespace KadabraMVC.Models
{
    public partial class Asistencia
    {
        public int IdAsistencia { get; set; }
        public int IdProfesor { get; set; }
        public int IdAlumno { get; set; }
        public int IdClase { get; set; }
        public DateTime? FyHRegistro { get; set; }

        public virtual Usuario IdAlumnoNavigation { get; set; } = null!;
        public virtual Clase IdClaseNavigation { get; set; } = null!;
        public virtual Usuario IdProfesorNavigation { get; set; } = null!;
    }
}
