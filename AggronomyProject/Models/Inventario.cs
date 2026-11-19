using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class Inventario
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_iventario")]
        public int id_inventario { get; set; }

        [Required(ErrorMessage = "Escribe el nombre del artículo."), StringLength(50, ErrorMessage = "El nombre debe tener como máximo 50 caracteres.")]
        public string nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Escribe una descripción breve."), StringLength(100, ErrorMessage = "La descripción debe tener como máximo 100 caracteres.")]
        public string descripcion { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Escribe un stock entero igual o mayor que cero.")]
        public int stock_actual { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Escribe un mínimo entero igual o mayor que cero.")]
        public int stock_minimo { get; set; }

        [Required(ErrorMessage = "Elige o escribe una unidad de medida."), StringLength(20, ErrorMessage = "La unidad debe tener como máximo 20 caracteres.")]
        public string unidad_medida { get; set; } = string.Empty;

        [Required]
        public DateTime fecha_actualizacion { get; set; }

        [Required]
        public bool estado { get; set; }

        [Required(ErrorMessage = "Elige un insumo base."), Range(1, int.MaxValue, ErrorMessage = "Elige un insumo base.")]
        public int id_producto_inicial { get; set; }
        public ProductoInicial productoinicial { get; set; } = null!;
        [Required(ErrorMessage = "Elige un producto final."), Range(1, int.MaxValue, ErrorMessage = "Elige un producto final.")]
        public int id_producto_final { get; set; }
        public ProductoFinal productofinal { get; set; } = null!;


        public ICollection<Administracion> administracion { get; set; } = new List<Administracion>();
    }
}
