using System.ComponentModel.DataAnnotations;

namespace AggronomyProject.ViewModels
{
    public class AdministracionCreateViewModel
    {
        [Required, StringLength(100)]
        public string? nombre { get; set; }

        [Required, StringLength(200)]
        public string? descripcion { get; set; }

        [Required]
        public DateTime? fecha_registro { get; set; }

        [Required, StringLength(100)]
        public string? responsable { get; set; }

        public bool estado { get; set; }

        [Required]
        public int? id_reporte { get; set; }

        [Required]
        public int? id_trabajador { get; set; }

        [Required]
        public int? id_inventario { get; set; }

        [Required]
        public int? id_metodo_pago { get; set; }

        [Required]
        public int? id_recursos_administrador { get; set; }
    }
}
