using Microsoft.EntityFrameworkCore;
namespace Broker.Models

{
    public class Broker_Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer("Data Source=(local); Initial Catalog=Broker; Integrated Security=true");
        }

        DbSet<Direccion> Direcciones { get; set; }
        DbSet<Persona> Personas { get; set; }
        DbSet<Orden> Ordenes { get; set; }
        DbSet<Accion> Acciones { get; set; }
        DbSet<Usuario> Usuarios { get; set; }

        // Hola

    }
}
