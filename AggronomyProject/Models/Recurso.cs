using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class Recurso
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_recurso { get; set; }

        [Required]
        public DateTime fecha_ingreso { get; set; }

        [Required]
        public int cantidad_recibida { get; set; }

        [Required, StringLength(20)]
        public string unidad_medida { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string tipo_recurso { get; set; } = string.Empty;

        [Required]
        public float costo_recurso { get; set; }

        [Required]
        public bool estado { get; set; }


        public ICollection<RecursosAdministrador> recursosadministrador { get; set; } = new List<RecursosAdministrador>();

        public int id_proveedor { get; set; }
        public Proveedor proveedor { get; set; } = null!;
    }
}