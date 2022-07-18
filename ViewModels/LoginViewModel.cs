using System.ComponentModel.DataAnnotations;

namespace KadabraMVC.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Ingrese una Dirección de Correo electrónico válida..")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100")]
        [DataType(DataType.EmailAddress,
            ErrorMessage = "Ingrese una Dirección de Correo electrónico válida.")]
        public string Mail { get; set; } = null!;




        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(15, ErrorMessage = "Longitud entre 4 y 15 caracteres.",
                      MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; } = null!;

        [Display(Name = "Recordarme")]
        public bool RememberMe { get; set; }
    }
}
