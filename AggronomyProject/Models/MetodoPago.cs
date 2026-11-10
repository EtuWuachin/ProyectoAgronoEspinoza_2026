using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class MetodoPago
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMetodoPago { get; set; }

        [Required, StringLength(50)]
        public string nombre { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string descripcion { get; set; } = string.Empty;

        [Required]
        public bool estado { get; set; }

        public int id_pago { get; set; }
        public Pago pago { get; set; } = null!;

        public ICollection<Administracion> administracion { get; set; } = new List<Administracion>();
    }
}