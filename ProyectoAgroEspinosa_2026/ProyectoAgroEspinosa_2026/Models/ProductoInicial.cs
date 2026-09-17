using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAgroEspinosa_2026.Models
{
    public class ProductoInicial
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_producto_inicial { get; set; }

        [Required, StringLength(50)]
        public string nombre { get; set; }

        [Required, StringLength(100)]
        public string descripcion { get; set; }

        [Required]
        public int cantidad_inicial { get; set; }

        [Required, StringLength(20)]
        public string unidad_medida { get; set; }

        [Required]
        public float costo_unitario { get; set; }

        [Required]
        public DateTime fecha_ingreso { get; set; }

        [Required, StringLength(50)]
        public string proveedor_origen { get; set; }

        [Required]
        public bool estado { get; set; }


        public ICollection<Inventario> inventario { get; set; }
    }
}
