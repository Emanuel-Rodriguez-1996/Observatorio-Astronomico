using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Confg
{
    public class PrestamoConfiguration : IEntityTypeConfiguration<Prestamo>
    {
        public void Configure(EntityTypeBuilder<Prestamo> builder)
        {
            builder.OwnsOne(p => p.FchFin, a =>
            {
                a.Property(x => x.Value).HasColumnName("FechaFin");
            });

            builder.OwnsOne(p => p.FchInicio, a =>
            {
                a.Property(x => x.Value).HasColumnName("FechaInicio");
            });

            builder.OwnsOne(p => p.Estado, a =>
            {
                a.Property(x => x.Value).HasColumnName("EstadoPrestamo");
            });

            // IMPORTANTE: evitar cascadas múltiples_________________________________________

            builder.HasOne(p => p.Telescopio)
                .WithMany()
                .HasForeignKey("TelescopioId")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Montura)
                .WithMany()
                .HasForeignKey("MonturaId")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Camara)
                .WithMany()
                .HasForeignKey("CamaraId")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Ocular)
                .WithMany()
                .HasForeignKey("OcularId")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Socio)
                .WithMany()
                .HasForeignKey("SocioId")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Coord)
                .WithMany()
                .HasForeignKey("CoordId")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
