using System.ComponentModel.DataAnnotations;

namespace KadabraMVC.ViewModels
{
    public class RegistroViewModel
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100 dígitos")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100 dígitos")]
        public string Apellido { get; set; } = null!;

        [Display(Name = "DNI")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(8, ErrorMessage = "Longitud máxima 8 dígitos")]
        [MinLength(7, ErrorMessage = "Longitud mínima 7 dígitos")]
        [RegularExpression("^[0-9]*$", ErrorMessage="Solo debe ingresar números.")]
        public string Dni { get; set; } = null!;

        [Display(Name = "Teléfono")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo debe ingresar números..")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string? Telefono { get; set; }

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100 dígitos")]
        public string? Direccion { get; set; }

        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100 dígitos")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Ingrese una Dirección de Correo electrónico válida.")]
        [DataType(DataType.EmailAddress,
            ErrorMessage = "Ingrese una Dirección de Correo electrónico válida.")]
        public string Mail { get; set; } = null!;

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100 dígitos")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; } = null!;

    }
}
