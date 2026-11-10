using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AggronomyProject.Models
{
    public class ProductoFinal
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_producto_final { get; set; }

        [Required, StringLength(50)]
        public string nombre { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string descripcion { get; set; } = string.Empty;

        [Required]
        public int cantidad_producida { get; set; }

        [Required, StringLength(20)]
        public string unidad_medida { get; set; } = string.Empty;

        [Required]
        public float precio_venta { get; set; }

        [Required]
        public bool estado { get; set; }


        public ICollection<Inventario> inventario { get; set; } = new List<Inventario>();
    }
}