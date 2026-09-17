using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAgroEspinosa_2026.Models
{
    public class MetodoPago
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMetodoPago { get; set; }

        [Required, StringLength(50)]
        public string nombre { get; set; }

        [Required, StringLength(100)]
        public string descripcion { get; set; }

        [Required]
        public bool estado { get; set; }

        public int id_pago { get; set; }
        public Pago pago { get; set; }

        public ICollection<T_AdmTT> administracion { get; set; }
    }
}
