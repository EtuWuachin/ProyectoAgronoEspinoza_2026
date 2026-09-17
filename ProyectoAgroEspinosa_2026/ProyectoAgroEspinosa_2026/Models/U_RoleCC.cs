using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAgroEspinosa_2026.Models
{
    public class U_RoleCC
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRol { get; set; }
        [Required, StringLength(50)]
        public string NombreRol { get; set; }
        [Required]
        public bool Estado { get; set; }

        public ICollection<M_UserTT> Usuario { get; set; }
    }
}
