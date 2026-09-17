using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAgroEspinosa_2026.Models
{
    public class M_UserTT
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
        [Required, StringLength(50)]
        public string NombreUsuario { get; set; }
        [Required, StringLength(100)]
        public string CorreoElectronico { get; set; }
        [Required, StringLength(100)]
        public string Contrasena { get; set; }
        public bool Estado { get; set; }

        public int IdRol { get; set; }
        public U_RoleCC Rol { get; set; }

    }
}
