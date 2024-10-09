using Microsoft.AspNetCore.Mvc;
using SistemaGestion.Data;
using SistemaGestion.Model;
using System;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return Ok(producto);
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Producto producto)
        {
            _context.Productos.Update(producto);
            _context.SaveChanges();
            return Ok(producto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null)
                return NotFound();
            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetProductos()
        {
            var productos = _context.Productos.ToList();
            return Ok(productos);
        }
    }
}
