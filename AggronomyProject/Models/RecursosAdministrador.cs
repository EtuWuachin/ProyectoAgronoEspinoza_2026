using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AggronomyProject.Models
{
    public class RecursosAdministrador
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_recursos_administrador { get; set; }

        [Required]
        public DateTime fecha_recepcion { get; set; }

        [Required]
        public int cantidad_recibida { get; set; }

        [Required, StringLength(50)]
        public string observaciones { get; set; }

        [Required]
        public bool estado { get; set; }


        public int id_recurso { get; set; }
        public Recurso recurso { get; set; }

    }
}
