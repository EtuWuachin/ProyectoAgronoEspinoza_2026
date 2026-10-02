using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class Rol
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRol { get; set; }
        [Required, StringLength(50)]
        public string NombreRol { get; set; }
        [Required]
        public bool Estado { get; set; }

        public ICollection<Usuario> Usuario { get; set; }

    }
}
