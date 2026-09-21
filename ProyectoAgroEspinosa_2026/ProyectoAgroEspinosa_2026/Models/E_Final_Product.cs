using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAgroEspinosa_2026.Models
{
    public class E_Final_Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProductoFinal { get; set; }

        [Required, StringLength(50)]
        public string nombre { get; set; }

        [Required, StringLength(100)]
        public string descripcion { get; set; }

        [Required]
        public int cantidadproducida { get; set; }

        [Required, StringLength(20)]
        public string unidadmedida { get; set; }

        [Required]
        public float precioventa { get; set; }

        [Required]
        public bool estado { get; set; }

        public ICollection<L_Inventory> inventario { get; set; }
    }
}