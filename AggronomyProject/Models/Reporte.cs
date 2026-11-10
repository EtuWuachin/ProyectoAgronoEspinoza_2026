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
        public string titulo { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string tipo_reporte { get; set; } = string.Empty;

        [Required]
        public DateTime fecha_generacion { get; set; }

        [Required]
        public string contenido { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string generado_por { get; set; } = string.Empty;

        [Required]
        public bool estado { get; set; }

        public ICollection<Administracion> administracion { get; set; } = new List<Administracion>();
    }
}