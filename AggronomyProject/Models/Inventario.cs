using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class Inventario
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int id_inventario { get; set; }

        [Required, StringLength(50)]
        public required string nombre { get; set; }

        [Required, StringLength(100)]
        public required string descripcion { get; set; }

        [Required]
        public required int stock_actual { get; set; }

        [Required]
        public required int stock_minimo { get; set; }

        [Required, StringLength(20)]
        public required string unidad_medida { get; set; }

        [Required]
        public required DateTime fecha_actualizacion { get; set; }

        [Required]
        public required bool estado { get; set; }

        public required int id_producto_inicial { get; set; }
        public required ProductoInicial productoinicial { get; set; }
        public required int id_producto_final { get; set; }
        public required ProductoFinal productofinal { get; set; }


        public required ICollection<Administracion> administracion { get; set; }
    }
}