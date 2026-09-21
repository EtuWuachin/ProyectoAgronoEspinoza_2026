using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAgroEspinosa_2026.Models
{
    public class A_Resource_Adm
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idRecursosAdministrador { get; set; }

        [Required]
        public DateTime fecharecepcion { get; set; }

        [Required]
        public int cantidadrecibida { get; set; }

        [Required, StringLength(50)]
        public string observaciones { get; set; }

        [Required]
        public bool estado { get; set; }


        public int idRecurso { get; set; }
        public R_Resource recurso { get; set; }

    }
}
