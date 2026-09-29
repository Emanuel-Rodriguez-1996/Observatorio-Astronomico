using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades.Equipo;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Confg
{
    public class MonturaConfiguration : IEntityTypeConfiguration<Montura>
    {
        public void Configure(EntityTypeBuilder<Montura> builder)
        {
            builder.OwnsOne(m => m.TipoMontura, t =>
            {
                t.Property(x => x.Value).HasColumnName("TipoMontura");
            });

            builder.OwnsOne(m => m.CargaSoportada, c =>
            {
                c.Property(x => x.Value).HasColumnName("CargaSoportada");
            });

            builder.OwnsOne(m => m.EsComputarizado, e =>
            {
                e.Property(x => x.Value).HasColumnName("EsComputarizado");
            });
        }
    }
}
