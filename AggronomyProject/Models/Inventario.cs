using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class Inventario
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_iventario")]
        public int id_inventario { get; set; }

        [Required, StringLength(50)]
        public string nombre { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string descripcion { get; set; } = string.Empty;

        [Required]
        public int stock_actual { get; set; }

        [Required]
        public int stock_minimo { get; set; }

        [Required, StringLength(20)]
        public string unidad_medida { get; set; } = string.Empty;

        [Required]
        public DateTime fecha_actualizacion { get; set; }

        [Required]
        public bool estado { get; set; }

        public int id_producto_inicial { get; set; }
        public ProductoInicial productoinicial { get; set; } = null!;
        public int id_producto_final { get; set; }
        public ProductoFinal productofinal { get; set; } = null!;


        public ICollection<Administracion> administracion { get; set; } = new List<Administracion>();
    }
}
