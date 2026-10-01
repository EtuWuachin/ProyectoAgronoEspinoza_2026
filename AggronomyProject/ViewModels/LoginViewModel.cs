using System.ComponentModel.DataAnnotations;

namespace AggronomyProject.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Ingrese su usuario o correo")]
        [Display(Name = "Usuario o correo")]
        public string Identificador { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese su contraseña")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; } = string.Empty;

        [Display(Name = "Recordarme")]
        public bool Recordarme { get; set; }
    }
}
