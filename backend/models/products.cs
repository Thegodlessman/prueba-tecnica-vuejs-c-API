namespace backend.Models 
{
    public class Producto
    {
        public int Id { get; set; } // Autoincremental por convención de EF Core
        public string? Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}