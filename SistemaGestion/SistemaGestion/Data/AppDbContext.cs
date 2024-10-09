using Microsoft.EntityFrameworkCore;
using SistemaGestion.Model;
using System.Collections.Generic;

namespace SistemaGestion.Data
{
    public class AppDbContext : DbContext
    {
        internal object productosVendidos;
        internal object ventas;

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<ProductoVendido> ProductosVendidos { get; set; }
    }
}
