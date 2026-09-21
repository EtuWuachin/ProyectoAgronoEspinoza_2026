using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAgroEspinosa_2026.Models
{
    public class T_AdmTT
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAdministracion { get; set; }

        [Required, StringLength(100)]
        public string nombre { get; set; }

        [Required, StringLength(200)]
        public string descripcion { get; set; }

        [Required]
        public DateTime fecharegistro { get; set; }

        [Required, StringLength(100)]
        public string responsable { get; set; }

        [Required]
        public bool estado { get; set; }

        // Relaciones (FKs)
        public int idReporte { get; set; }
        public G_Report reporte { get; set; }

        public int idTrabajador { get; set; }
        public K_Worker trabajador { get; set; }

        public int idInventario { get; set; }
        public L_Inventory inventario { get; set; }

        public int IdPago { get; set; }
        public F_Paid pago { get; set; }

        public int idRecursosAdministrador { get; set; }
        public A_Resource_Adm recursosadministrador { get; set; }
    }
}