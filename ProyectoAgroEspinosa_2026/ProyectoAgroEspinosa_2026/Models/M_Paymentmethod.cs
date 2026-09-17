using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAgroEspinosa_2026.Models
{
    public class M_Paymentmethod
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMetodoPago { get; set; }

        [Required, StringLength(50)]
        public string nombre { get; set; }

        [Required, StringLength(100)]
        public string descripcion { get; set; }

        [Required]
        public bool estado { get; set; }

        public ICollection<F_Paid> pagos { get; set; }

    }
}
