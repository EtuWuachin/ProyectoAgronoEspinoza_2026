using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAgroEspinosa_2026.Models
{
    public class E_Initial_Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProductoInicial { get; set; }

        [Required, StringLength(50)]
        public string nombre { get; set; }

        [Required, StringLength(100)]
        public string descripcion { get; set; }

        [Required]
        public int cantidadinicial { get; set; }

        [Required, StringLength(20)]
        public string unidadmedida { get; set; }

        [Required]
        public float costounitario { get; set; }

        [Required]
        public DateTime fechaingreso { get; set; }

        [Required, StringLength(50)]
        public string proveedororigen { get; set; }

        [Required]
        public bool estado { get; set; }

        public ICollection<L_Inventory> inventario { get; set; }
    }
}