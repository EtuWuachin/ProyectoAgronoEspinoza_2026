using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class Administracion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAdministracion { get; set; }

        [Required, StringLength(100)]
        public string nombre { get; set; } = string.Empty;

        [Required, StringLength(200)]
        public string descripcion { get; set; } = string.Empty;

        [Required]
        public DateTime fecha_registro { get; set; }

        [Required, StringLength(100)]
        public string responsable { get; set; } = string.Empty;

        [Required]
        public bool estado { get; set; }

        // Relaciones (FKs)
        public int id_reporte { get; set; }
        public Reporte reporte { get; set; } = null!;

        public int id_trabajador { get; set; }
        public Trabajador trabajador { get; set; } = null!;

        public int id_inventario { get; set; }
        public Inventario inventario { get; set; } = null!;

        public int id_metodo_pago { get; set; }
        public MetodoPago metodopago { get; set; } = null!;

        public int id_recursos_administrador { get; set; }
        public RecursosAdministrador recursosadministrador { get; set; } = null!;

    }
}