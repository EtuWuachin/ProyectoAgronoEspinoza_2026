using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AggronomyProject.Models
{
    public class ProductoFinal
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int id_producto_final { get; set; }

        [Required, StringLength(50)]
        public required string nombre { get; set; }

        [Required, StringLength(100)]
        public required string descripcion { get; set; }

        [Required]
        public required int cantidad_producida { get; set; }

        [Required, StringLength(20)]
        public required string unidad_medida { get; set; }

        [Required]
        public required float precio_venta { get; set; }

        [Required]
        public required bool estado { get; set; }


        public required ICollection<Inventario> inventario { get; set; }
    }
}