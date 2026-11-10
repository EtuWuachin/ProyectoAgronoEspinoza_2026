using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class Trabajador
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_trabajador { get; set; }

        [Required, StringLength(50)]
        public string nombres { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string apellidos { get; set; } = string.Empty;

        [Required, StringLength(15)]
        public string dni { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string cargo { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string telefono { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string email { get; set; } = string.Empty;

        [Required]
        public DateTime fecha_contrato { get; set; }

        [Required]
        public bool estado { get; set; }

        public ICollection<Administracion> administracion { get; set; } = new List<Administracion>();

    }
}