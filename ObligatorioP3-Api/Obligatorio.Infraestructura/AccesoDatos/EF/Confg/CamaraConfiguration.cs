using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades.Equipo;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Confg
{
    public class CamaraConfiguration : IEntityTypeConfiguration<Camara>
    {
        public void Configure(EntityTypeBuilder<Camara> builder)
        {
            builder.OwnsOne(c => c.Pixel, p =>
            {
                p.Property(x => x.Value).HasColumnName("Pixel");
            });

            builder.OwnsOne(c => c.Resolucion, r =>
            {
                r.Property(x => x.Value).HasColumnName("Resolucion");
            });

            builder.OwnsOne(c => c.TipoSensor, t =>
            {
                t.Property(x => x.Value).HasColumnName("TipoSensor");
            });
        }
    }
}
