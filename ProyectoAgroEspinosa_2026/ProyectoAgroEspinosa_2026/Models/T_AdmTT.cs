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
        public DateTime fecha_registro { get; set; }

        [Required, StringLength(100)]
        public string responsable { get; set; }

        [Required]
        public bool estado { get; set; }

        //Relaciones(FKs)
        public int id_reporte { get; set; }
        public Reporte reporte { get; set; }

        public int id_trabajador { get; set; }
        public Trabajador trabajador { get; set; }

        public int id_inventario { get; set; }
        public Inventario inventario { get; set; }

        public int id_metodo_pago { get; set; }
        public MetodoPago metodopago { get; set; }

        public int id_recursos_administrador { get; set; }
        public A_Resource_Adm recursosadministrador { get; set; }
    }
}
