using Microsoft.AspNetCore.Mvc;
using SistemaGestion.Data;
using SistemaGestion.Model;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VentaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Createventa([FromBody] Venta venta)
        {
            _context.Ventas.Add(venta);
            _context.SaveChanges();
            return Ok(venta);
        }

        [HttpDelete("{id}")]
        public IActionResult Deleteventa(int id)
        {
            var venta = _context.Ventas.Find(id);
            if (venta == null)
                return NotFound();

            Dictionary<int, ProductoVendido> ProductosVendidos = _context.ProductosVendidos.Where(sp => sp.Id == id).ToDictionary(sp => sp.Id, sp => sp);

            ProductoVendido ProductoVendido;
            if (ProductosVendidos.Remove(id, out ProductoVendido))
            {
                var producto = _context.Productos.Find(ProductoVendido.ProductoId);
                if (producto != null)
                {
                    producto.Stock += ProductoVendido.Cantidad;
                    _context.ProductosVendidos.Remove(ProductoVendido);
                }
            }
            else
            {
                return NotFound();
            }

            _context.Ventas.Remove(venta);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult Getventas()
        {
            var ventas = _context.Ventas.ToList();
            return Ok(ventas);
        }
    }
}
