using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class Inventario
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_iventario { get; set; }

        [Required, StringLength(50)]
        public required string nombre { get; set; }

        [Required, StringLength(100)]
        public required string descripcion { get; set; }

        [Required]
        public int stock_actual { get; set; }

        [Required]
        public int stock_minimo { get; set; }

        [Required, StringLength(20)]
        public required string unidad_medida { get; set; }

        [Required]
        public DateTime fecha_actualizacion { get; set; }

        [Required]
        public bool estado { get; set; }

        public int id_producto_inicial { get; set; }
        public required ProductoInicial productoinicial { get; set; }
        public int id_producto_final { get; set; }
        public required ProductoFinal productofinal { get; set; }


        public required ICollection<Administracion> administracion { get; set; }
    }
}