using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAgroEspinosa_2026.Models
{
    public class ProductoFinal
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_producto_final { get; set; }

        [Required, StringLength(50)]
        public string nombre { get; set; }

        [Required, StringLength(100)]
        public string descripcion { get; set; }

        [Required]
        public int cantidad_producida { get; set; }

        [Required, StringLength(20)]
        public string unidad_medida { get; set; }

        [Required]
        public float precio_venta { get; set; }

        [Required]
        public bool estado { get; set; }


        public ICollection<Inventario> inventario { get; set; }
    }
}
