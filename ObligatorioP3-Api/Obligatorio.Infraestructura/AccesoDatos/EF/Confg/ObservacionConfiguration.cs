using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Confg
{
    public class ObservacionConfiguration : IEntityTypeConfiguration<Observacion>
    {
        public void Configure(EntityTypeBuilder<Observacion> builder)
        {
            builder.HasKey(o => o.Id);

            builder.OwnsOne(p => p.Fecha, a =>
            {
                a.Property(x => x.Value)
                 .HasColumnName("Fecha");
            });

            // Relación con Prestamo
            builder.HasOne(o => o.Prestamo)
                .WithMany()
                .HasForeignKey("PrestamoId")
                .OnDelete(DeleteBehavior.NoAction);

            // Relación con ObjCeleste
            builder.HasOne(o => o.ObjCeleste)
                .WithMany()
                .HasForeignKey("ObjCelesteId")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}