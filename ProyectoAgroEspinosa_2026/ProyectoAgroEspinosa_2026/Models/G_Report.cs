using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAgroEspinosa_2026.Models
{
    public class G_Report
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_reporte { get; set; }

        [Required, StringLength(100)]
        public string titulo { get; set; }

        [Required, StringLength(50)]
        public string tipo_reporte { get; set; }

        [Required]
        public DateTime fecha_generacion { get; set; }

        [Required]
        public string contenido { get; set; }

        [Required, StringLength(50)]
        public string generado_por { get; set; }

        [Required]
        public bool estado { get; set; }

        public ICollection<Administracion> administracion { get; set; }
    }
}
