using AggronomyProject.Models;

namespace AggronomyProject.ViewModels
{
    public class InventarioFilterViewModel
    {
        public string? Busqueda { get; set; }
        public bool SoloStockBajo { get; set; }
        public bool SoloActivos { get; set; } = true;
        public List<Inventario> Items { get; set; } = new();
    }
}
