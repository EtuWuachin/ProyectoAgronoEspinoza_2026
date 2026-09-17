using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAgroEspinosa_2026.Models
{
    public class R_Resource
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_recurso { get; set; }

        [Required]
        public DateTime fecha_ingreso { get; set; }

        [Required]
        public int cantidad_recibida { get; set; }

        [Required, StringLength(20)]
        public string unidad_medida { get; set; }

        [Required, StringLength(20)]
        public string tipo_recurso { get; set; }

        [Required]
        public float costo_recurso { get; set; }

        [Required]
        public bool estado { get; set; }


        public ICollection<A_Resource_Adm> recursosadministrador { get; set; }

        public int id_proveedor { get; set; }
        public Proveedor proveedor { get; set; }
    }
}
