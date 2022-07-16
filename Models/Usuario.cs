using System;
using System.Collections.Generic;

namespace KadabraMVC.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            AnotacionAclases = new HashSet<AnotacionAclase>();
            AsistenciaIdAlumnoNavigations = new HashSet<Asistencia>();
            AsistenciaIdProfesorNavigations = new HashSet<Asistencia>();
            Clases = new HashSet<Clase>();
            PagoIdAdministrativoNavigations = new HashSet<Pago>();
            PagoIdAlumnoNavigations = new HashSet<Pago>();
            RegistroDeClases = new HashSet<RegistroDeClase>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Dni { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string Mail { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public DateTime? FechaDeAlta { get; set; }
        public string? Estado { get; set; }
        public int? ClasesRestantes { get; set; }
        public string Tipo { get; set; } = null!;

        public virtual ICollection<AnotacionAclase> AnotacionAclases { get; set; }
        public virtual ICollection<Asistencia> AsistenciaIdAlumnoNavigations { get; set; }
        public virtual ICollection<Asistencia> AsistenciaIdProfesorNavigations { get; set; }
        public virtual ICollection<Clase> Clases { get; set; }
        public virtual ICollection<Pago> PagoIdAdministrativoNavigations { get; set; }
        public virtual ICollection<Pago> PagoIdAlumnoNavigations { get; set; }
        public virtual ICollection<RegistroDeClase> RegistroDeClases { get; set; }
    }
}
