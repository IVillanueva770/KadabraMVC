using System.ComponentModel.DataAnnotations;

namespace KadabraMVC.ViewModels
{
    public class NuevoPagoViewModel
    {
        public int IdPago { get; set; }
        public int IdAdministrativo { get; set; }
        public int IdAlumno { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [MinLength(7)]
        [MaxLength(8)]
        public string? DNI { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")] 
        public string? MesPagado { get; set; }
        public DateTime FyHRegistro { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Range(1, 12, ErrorMessage = "Valor máximo: 12")]
        public int CantidadMesesPagados { get; set; }
        public int Monto { get; set; }
    }
}
