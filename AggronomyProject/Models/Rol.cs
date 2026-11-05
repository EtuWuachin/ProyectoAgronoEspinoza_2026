using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class Rol
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int IdRol { get; set; }
        [Required, StringLength(50)]
        public required string NombreRol { get; set; }
        [Required]
        public required bool Estado { get; set; }

        public required ICollection<Usuario> Usuario { get; set; }

    }
}
