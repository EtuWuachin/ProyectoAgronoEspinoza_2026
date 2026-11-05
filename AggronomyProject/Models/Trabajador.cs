using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class Trabajador
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int id_trabajador { get; set; }

        [Required, StringLength(50)]
        public required string nombres { get; set; }

        [Required, StringLength(50)]
        public required string apellidos { get; set; }

        [Required, StringLength(15)]
        public required string dni { get; set; }

        [Required, StringLength(50)]
        public required string cargo { get; set; }

        [Required, StringLength(20)]
        public required string telefono { get; set; }

        [Required, StringLength(100)]
        public required string email { get; set; }

        [Required]
        public required DateTime fecha_contrato { get; set; }

        [Required]
        public required bool estado { get; set; } 

        public required ICollection<Administracion> administracion { get; set; }
        
    }
}