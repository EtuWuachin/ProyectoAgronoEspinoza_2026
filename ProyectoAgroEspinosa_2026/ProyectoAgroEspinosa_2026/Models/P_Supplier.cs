using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAgroEspinosa_2026.Models
{
    public class P_Supplier
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProveedor { get; set; }

        [Required, StringLength(50)]
        public string nombre { get; set; }

        [Required, StringLength(30)]
        public string ruc { get; set; }

        [Required, StringLength(50)]
        public string direccion { get; set; }

        [Required, StringLength(20)]
        public string telefono { get; set; }

        [Required, StringLength(30)]
        public string email { get; set; }

        [Required]
        public bool estado { get; set; }


        public ICollection<R_Resource> recurso { get; set; }
    }
}
