using AggronomyProject.Models;

namespace AggronomyProject.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalProductosIniciales { get; set; }
        public int TotalProductosFinales { get; set; }
        public int TotalTrabajadores { get; set; }
        public int TotalProveedores { get; set; }
        public decimal TotalPagosMes { get; set; }
        public List<Inventario> AlertasStock { get; set; } = new();
        public List<Pago> UltimosPagos { get; set; } = new();
    }
}
