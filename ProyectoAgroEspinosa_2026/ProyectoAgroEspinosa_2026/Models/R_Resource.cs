using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAgroEspinosa_2026.Models
{
    public class R_Resource
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idRecurso { get; set; }

        [Required]
        public DateTime fechaingreso { get; set; }

        [Required]
        public int cantidadrecibida { get; set; }

        [Required, StringLength(20)]
        public string unidadmedida { get; set; }

        [Required, StringLength(20)]
        public string tiporecurso { get; set; }

        [Required]
        public float costorecurso { get; set; }

        [Required]
        public bool estado { get; set; }

        public ICollection<A_Resource_Adm> recursosadministrador { get; set; }

        public int idProveedor { get; set; }
        public P_Supplier proveedor { get; set; }
    }
}