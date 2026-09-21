using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAgroEspinosa_2026.Models
{
    public class G_Report
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idReporte { get; set; }

        [Required, StringLength(100)]
        public string titulo { get; set; }

        [Required, StringLength(50)]
        public string tiporeporte { get; set; }

        [Required]
        public DateTime fechageneracion { get; set; }

        [Required]
        public string contenido { get; set; }

        [Required, StringLength(50)]
        public string generadopor { get; set; }

        [Required]
        public bool estado { get; set; }

        public ICollection<T_AdmTT> administracion { get; set; }
    }
}
