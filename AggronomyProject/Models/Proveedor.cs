using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class Proveedor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_proveedor { get; set; }

        [Required(ErrorMessage = "Escribe el nombre o razón social."), StringLength(50, ErrorMessage = "El nombre debe tener como máximo 50 caracteres.")]
        public string nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Escribe el RUC del proveedor."), StringLength(30, ErrorMessage = "El RUC debe tener como máximo 30 caracteres.")]
        public string ruc { get; set; } = string.Empty;

        [Required(ErrorMessage = "Escribe la dirección del proveedor."), StringLength(50, ErrorMessage = "La dirección debe tener como máximo 50 caracteres.")]
        public string direccion { get; set; } = string.Empty;

        [Required(ErrorMessage = "Escribe un teléfono de contacto."), StringLength(20, ErrorMessage = "El teléfono debe tener como máximo 20 caracteres.")]
        public string telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "Escribe el correo del proveedor."), EmailAddress(ErrorMessage = "Escribe un correo válido, como contacto@proveedor.com."), StringLength(30, ErrorMessage = "El correo debe tener como máximo 30 caracteres.")]
        public string email { get; set; } = string.Empty;

        [Required]
        public bool estado { get; set; }


        public ICollection<Recurso> recurso { get; set; } = new List<Recurso>();
    }
}
