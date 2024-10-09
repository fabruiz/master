using Microsoft.AspNetCore.Mvc;
using SistemaGestion.Data;
using SistemaGestion.Model;
using System.Linq;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoVendidoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductoVendidoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CrearProductoVendido([FromBody] ProductoVendido productoVendido)
        {
            _context.ProductosVendidos.Add(productoVendido);
            _context.SaveChanges();
            return Ok(productoVendido);
        }

        [HttpPut]
        public IActionResult ModificarProductoVendido([FromBody] ProductoVendido productoVendido)
        {
            _context.ProductosVendidos.Update(productoVendido);
            _context.SaveChanges();
            return Ok(productoVendido);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarProductoVendido(int id)
        {
            var productoVendido = _context.ProductosVendidos.Find(id);
            if (productoVendido == null)
                return NotFound();

            _context.ProductosVendidos.Remove(productoVendido);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult ObtenerProductosVendidos()
        {
            var productoVendidos = _context.ProductosVendidos.ToList();
            return Ok(productoVendidos);
        }
    }
}
