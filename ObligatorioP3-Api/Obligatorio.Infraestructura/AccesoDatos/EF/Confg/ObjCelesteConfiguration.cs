using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Confg
{
    public class ObjCelesteConfiguration : IEntityTypeConfiguration<ObjCeleste>
    {
        public void Configure(EntityTypeBuilder<ObjCeleste> builder)
        {
            builder.OwnsOne(o => o.Magnitud, o =>
            {
                o.Property(x => x.Value).HasColumnName("Magnitud");
            });

            builder.OwnsOne(o => o.Nombre, o =>
            {
                o.Property(x => x.Value).HasColumnName("Nombre");
            });

            builder.OwnsOne(o => o.Tipo, o =>
            {
                o.Property(x => x.Value).HasColumnName("Tipo");
            });
        }

    }
}
