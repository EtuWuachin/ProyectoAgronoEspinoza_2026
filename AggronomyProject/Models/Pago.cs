using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class Pago
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int IdPago { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")] // !Precision de 18 escala de 2
        public required decimal monto { get; set; }

        [Required]
        public required DateTime fecha_pago { get; set; }

        [Required, StringLength(100)]
        public required string concepto { get; set; }

        [Required, StringLength(50)]
        public required string comprobante { get; set; }

        [Required]
        public required bool estado { get; set; } 

        public required ICollection<MetodoPago> metodopago { get; set; }
    }
}