using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades.Equipo;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Confg
{
    public class TelescopioConfiguration : IEntityTypeConfiguration<Telescopio>
    {
        public void Configure(EntityTypeBuilder<Telescopio> builder)
        {
            builder.OwnsOne(t => t.Apertura, a =>
            {
                a.Property(x => x.Value).HasColumnName("Apertura");
            });

            builder.OwnsOne(t => t.RelacionFocal, r =>
            {
                r.Property(x => x.Value).HasColumnName("RelacionFocal");
            });

            builder.OwnsOne(t => t.DistanciaFocal, d =>
            {
                d.Property(x => x.Value).HasColumnName("DistanciaFocal");
            });

            builder.OwnsOne(t => t.Peso, p =>
            {
                p.Property(x => x.Value).HasColumnName("Peso");
            });
        }
    }
}
