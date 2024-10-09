namespace SistemaGestion.Model
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public decimal TotalProducto { get; set; }
        public decimal Categoria { get; set; }
    }
}
