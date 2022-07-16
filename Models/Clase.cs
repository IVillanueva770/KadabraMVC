using System;
using System.Collections.Generic;

namespace KadabraMVC.Models
{
    public partial class Clase
    {
        public Clase()
        {
            AnotacionAclases = new HashSet<AnotacionAclase>();
            Asistencia = new HashSet<Asistencia>();
            RegistroDeClases = new HashSet<RegistroDeClase>();
        }

        public int IdClase { get; set; }
        public int? IdProfesor { get; set; }
        public DateTime HorarioClase { get; set; }
        public string? Estado { get; set; }

        public virtual Usuario? IdProfesorNavigation { get; set; }
        public virtual ICollection<AnotacionAclase> AnotacionAclases { get; set; }
        public virtual ICollection<Asistencia> Asistencia { get; set; }
        public virtual ICollection<RegistroDeClase> RegistroDeClases { get; set; }
    }
}
