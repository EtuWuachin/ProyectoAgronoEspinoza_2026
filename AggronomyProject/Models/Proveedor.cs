using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class Proveedor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_proveedor { get; set; }

        [Required, StringLength(50)]
        public string nombre { get; set; } = string.Empty;

        [Required, StringLength(30)]
        public string ruc { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string direccion { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string telefono { get; set; } = string.Empty;

        [Required, StringLength(30)]
        public string email { get; set; } = string.Empty;

        [Required]
        public bool estado { get; set; }


        public ICollection<Recurso> recurso { get; set; } = new List<Recurso>();
    }
}
