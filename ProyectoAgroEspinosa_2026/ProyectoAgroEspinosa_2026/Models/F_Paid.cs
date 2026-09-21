using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAgroEspinosa_2026.Models
{
    public class F_Paid
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPago { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal monto { get; set; }

        [Required]
        public DateTime fechapago { get; set; }

        [Required, StringLength(100)]
        public string concepto { get; set; }

        [Required, StringLength(50)]
        public string comprobante { get; set; }

        [Required]
        public bool estado { get; set; }


        public int IdMetodoPago { get; set; }

        public M_Paymentmethod metodopago { get; set; }

        public ICollection<T_AdmTT> administracion { get; set; }
    }
}
