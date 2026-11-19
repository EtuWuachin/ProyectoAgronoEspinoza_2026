using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class Pago
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPago { get; set; }

        [Required(ErrorMessage = "Escribe el monto en soles."), Column(TypeName = "decimal(18,2)")] // !Precision de 18 escala de 2
        public decimal monto { get; set; }

        [Required(ErrorMessage = "Elige la fecha del pago.")]
        public DateTime fecha_pago { get; set; }

        [Required(ErrorMessage = "Escribe qué se pagó."), StringLength(100, ErrorMessage = "El concepto debe tener como máximo 100 caracteres.")]
        public string concepto { get; set; } = string.Empty;

        [Required(ErrorMessage = "Escribe el número de comprobante."), StringLength(50, ErrorMessage = "El comprobante debe tener como máximo 50 caracteres.")]
        public string comprobante { get; set; } = string.Empty;

        [Required]
        public bool estado { get; set; }

        public ICollection<MetodoPago> metodopago { get; set; } = new List<MetodoPago>();
    }
}
