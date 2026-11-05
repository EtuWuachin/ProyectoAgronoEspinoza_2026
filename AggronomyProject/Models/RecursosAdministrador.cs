using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class RecursosAdministrador
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int id_recursos_administrador { get; set; }

        [Required]
        public required DateTime fecha_recepcion { get; set; }

        [Required]
        public required int cantidad_recibida { get; set; }

        [Required, StringLength(50)]
        public required string observaciones { get; set; }

        [Required]
        public required bool estado { get; set; }


        public required int id_recurso { get; set; }
        public required Recurso recurso { get; set; }

    }
}
