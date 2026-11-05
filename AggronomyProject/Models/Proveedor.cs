using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class Proveedor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int id_proveedor { get; set; }

        [Required, StringLength(50)]
        public required string nombre { get; set; }

        [Required, StringLength(30)]
        public required string ruc { get; set; }

        [Required, StringLength(50)]
        public required string direccion { get; set; }

        [Required, StringLength(20)]
        public required string telefono { get; set; }

        [Required, StringLength(30)]
        public required string email { get; set; }

        [Required]
        public required bool estado { get; set; }


        public required ICollection<Recurso> recurso { get; set; }
    }
}
