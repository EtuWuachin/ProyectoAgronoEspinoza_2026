using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAgroEspinosa_2026.Models
{
    public class L_Inventory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idInventario { get; set; }

        [Required, StringLength(50)]
        public string nombre { get; set; }

        [Required, StringLength(100)]
        public string descripcion { get; set; }

        [Required]
        public int stockactual { get; set; }

        [Required]
        public int stockminimo { get; set; }

        [Required, StringLength(20)]
        public string unidadmedida { get; set; }

        [Required]
        public DateTime fechaactualizacion { get; set; }

        [Required]
        public bool estado { get; set; }

        public int idProductoInicial { get; set; }
        public E_Initial_Product productoinicial { get; set; }

        public int idProductoFinal { get; set; }
        public E_Final_Product productofinal { get; set; }

        public ICollection<T_AdmTT> administracion { get; set; }
    }
}