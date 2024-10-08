using Microsoft.EntityFrameworkCore;
using SistemaGestionEntities;

namespace SistemaGestionData.Contexts;

public class MyDbContext : DbContext
{
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<ProductoVendido> ProductoVendido { get; set; }
    public DbSet<Venta> Venta { get; set; }

    public MyDbContext()
        : base() { }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-P5EBME4;Initial Catalog=ProyectoFinal;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
    }
}

