using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class Usuario
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
        [Required, StringLength(50)]
        public required string NombreUsuario { get; set; }
        [Required, StringLength(100)]
        public required string CorreoElectronico { get; set; }
        [Required, StringLength(100)]
        public required string Contrasena { get; set; }
        public bool Estado { get; set; }

        public int IdRol { get; set; }
        public required Rol Rol { get; set; } 
    }
}
