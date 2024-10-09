namespace SistemaGestion.Model
{
    public class ProductoVendido
    {
        public int Id { get; internal set; }
        public int VentaId { get; set; }
        public int ProductoId { get; internal set; }
        public int Cantidad { get; internal set; }
    }
}
