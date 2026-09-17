using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAgroEspinosa_2026.Models
{
    public class Inventario
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_iventario { get; set; }

        [Required, StringLength(50)]
        public string nombre { get; set; }

        [Required, StringLength(100)]
        public string descripcion { get; set; }

        [Required]
        public int stock_actual { get; set; }

        [Required]
        public int stock_minimo { get; set; }

        [Required, StringLength(20)]
        public string unidad_medida { get; set; }

        [Required]
        public DateTime fecha_actualizacion { get; set; }

        [Required]
        public bool estado { get; set; }

        public int id_producto_inicial { get; set; }
        public ProductoInicial productoinicial { get; set; }
        public int id_producto_final { get; set; }
        public ProductoFinal productofinal { get; set; }


        public ICollection<T_AdmTT> administracion { get; set; }
    }
}
