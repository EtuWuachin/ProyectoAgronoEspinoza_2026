using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class Administracion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int IdAdministracion { get; set; }

        [Required, StringLength(100)]
        public required string nombre { get; set; }

        [Required, StringLength(200)]
        public required string descripcion { get; set; }

        [Required]
        public DateTime fecha_registro { get; set; }

        [Required, StringLength(100)]
        public required string responsable { get; set; }

        [Required]
        public bool estado { get; set; } 

        // Relaciones (FKs)
        public int id_reporte { get; set; }
        public required Reporte reporte { get; set; }

        public int id_trabajador { get; set; }
        public required Trabajador trabajador { get; set; }

        public int id_inventario { get; set; }
        public required Inventario inventario { get; set; }

        public int id_metodo_pago { get; set; }
        public required MetodoPago metodopago { get; set; }

        public int id_recursos_administrador { get; set; }
        public required RecursosAdministrador recursosadministrador { get; set; }

    }
}