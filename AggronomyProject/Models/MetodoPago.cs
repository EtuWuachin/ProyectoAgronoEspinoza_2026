using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class MetodoPago
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int IdMetodoPago { get; set; }

        [Required, StringLength(50)]
        public required string nombre { get; set; }

        [Required, StringLength(100)]
        public required string descripcion { get; set; }

        [Required]
        public required bool estado { get; set; } 

        public required int id_pago { get; set; }
        public required Pago pago { get; set; }

        public required ICollection<Administracion> administracion { get; set; }
    }
}