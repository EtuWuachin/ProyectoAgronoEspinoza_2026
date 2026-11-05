using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Org.BouncyCastle.Ocsp;

namespace AggronomyProject.Models
{
    public class Reporte
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_reporte { get; set; }

        [Required, StringLength(100)]
        public required string titulo { get; set; }

        [Required, StringLength(50)]
        public required string tipo_reporte { get; set; }

        [Required]
        public DateTime fecha_generacion { get; set; }

        [Required]
        public required string contenido { get; set; }

        [Required, StringLength(50)]
        public required string generado_por { get; set; }

        [Required]
        public bool estado { get; set; } 

        public required ICollection<Administracion> administracion { get; set; }
    }
}