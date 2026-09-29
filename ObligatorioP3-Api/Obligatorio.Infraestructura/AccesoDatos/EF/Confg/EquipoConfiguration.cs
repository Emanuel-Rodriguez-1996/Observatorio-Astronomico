using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades.Equipo;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Confg
{
    public class EquipoConfiguration : IEntityTypeConfiguration<Equipo>
    {
        public void Configure(EntityTypeBuilder<Equipo> builder)
        {

            builder.OwnsOne(equipo => equipo.Marca, VOMarca =>
            {
                VOMarca.Property(n => n.Value).HasColumnName("Marca").IsRequired();
            });
            builder.OwnsOne(equipo => equipo.Modelo, VOModelo =>
            {
                VOModelo.Property(b => b.Value).HasColumnName("Modelo").IsRequired();
            });
            builder.OwnsOne(equipo => equipo.Cantidad, VOCantDisp =>
            {
                VOCantDisp.Property(c => c.Value).HasColumnName("CantDisp").IsRequired();
            });
        }
    }
}
