using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAgroEspinosa_2026.Models
{
    public class A_Resource_Adm
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
        public R_Resource recurso { get; set; }

    }
}
