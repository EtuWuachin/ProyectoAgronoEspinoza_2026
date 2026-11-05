using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class Recurso
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int id_recurso { get; set; }

        [Required]
        public required DateTime fecha_ingreso { get; set; }

        [Required]
        public required int cantidad_recibida { get; set; }

        [Required, StringLength(20)]
        public required string unidad_medida { get; set; }

        [Required, StringLength(20)]
        public required string tipo_recurso { get; set; }

        [Required]
        public required float costo_recurso { get; set; }

        [Required]
        public required bool estado { get; set; }


        public required ICollection<RecursosAdministrador> recursosadministrador { get; set; }

        public required int id_proveedor { get; set; }
        public required Proveedor proveedor { get; set; }
    }
}