using Microsoft.EntityFrameworkCore;
namespace Broker.Models

{
    public class Broker_Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer("Data Source=FEDE\\SQLEXPRESS01; Initial Catalog=Broker; Integrated Security=true");
        }

        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Accion> Acciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        

    }
}
