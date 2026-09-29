using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades.Equipo;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Confg
{
    public class OcularConfiguration : IEntityTypeConfiguration<Ocular>
    {
        public void Configure(EntityTypeBuilder<Ocular> builder)
        {
            builder.OwnsOne(o => o.Angulo, a =>
            {
                a.Property(x => x.Value).HasColumnName("Angulo");
            });

            builder.OwnsOne(o => o.Diametro, d =>
            {
                d.Property(x => x.Value).HasColumnName("Diametro");
            });
        }
    }
}
