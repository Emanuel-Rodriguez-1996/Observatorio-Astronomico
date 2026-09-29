using Microsoft.EntityFrameworkCore;
using Obligatorio.Infraestructura.AccesoDatos.EF.Confg;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Entidades.EnUsuarios;
using Obligatorio.LogicaNegocio.Entidades.Equipo;

namespace Obligatorio.Infraestructura.AccesoDatos.EF
{
    public class ObservatorioContext : DbContext
    {
        public ObservatorioContext()
        {
        }

        public ObservatorioContext(DbContextOptions<ObservatorioContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UserAdmin> Administradores { get; set; }
        public DbSet<UserCoordinador> Coordinadores { get; set; }
        public DbSet<UserSocio> Socios { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Camara> Camaras { get; set; }
        public DbSet<Telescopio> Telescopios { get; set; }
        public DbSet<Ocular> Oculares { get; set; }
        public DbSet<Montura> Monturas { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<AuditoriaPrestamo> AuditoriaPrestamos { get; set; }
        public DbSet<Observacion> Observaciones { get; set; }
        public DbSet<ObjCeleste> ObjCelestes { get; set; }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ObservatorioDB;Integrated Security=True;");
        }*/

        //public ObservatorioContext(DbContextOptions<ObservatorioContext> options) : base(options)
        //{

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EquipoConfiguration());
            modelBuilder.ApplyConfiguration(new CamaraConfiguration());
            modelBuilder.ApplyConfiguration(new TelescopioConfiguration());
            modelBuilder.ApplyConfiguration(new OcularConfiguration());
            modelBuilder.ApplyConfiguration(new MonturaConfiguration());
            modelBuilder.ApplyConfiguration(new PrestamoConfiguration());
            modelBuilder.ApplyConfiguration(new ObjCelesteConfiguration());
            modelBuilder.ApplyConfiguration(new ObservacionConfiguration());
            modelBuilder.ApplyConfiguration(new AuditoriaPrestamoConfiguration());
        }
    }
}
