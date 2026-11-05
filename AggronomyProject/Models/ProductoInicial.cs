using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class ProductoInicial
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int id_producto_inicial { get; set; }

        [Required, StringLength(50)]
        public required string nombre { get; set; }

        [Required, StringLength(100)]
        public required string descripcion { get; set; }

        [Required]
        public required int cantidad_inicial { get; set; }

        [Required, StringLength(20)]
        public required string unidad_medida { get; set; }

        [Required]
        public required float costo_unitario { get; set; }

        [Required]
        public required DateTime fecha_ingreso { get; set; }

        [Required, StringLength(50)]
        public required string proveedor_origen { get; set; }

        [Required]
        public required bool estado { get; set; }


        public required ICollection<Inventario> inventario { get; set; }
    }
}
