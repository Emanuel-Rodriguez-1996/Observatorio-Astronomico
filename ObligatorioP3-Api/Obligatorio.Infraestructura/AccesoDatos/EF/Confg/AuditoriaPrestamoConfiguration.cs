using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Confg
{
    public class AuditoriaPrestamoConfiguration : IEntityTypeConfiguration<AuditoriaPrestamo>
    {
        public void Configure(EntityTypeBuilder<AuditoriaPrestamo> builder)
        {
            builder.HasKey(a => a.Id);

            builder.OwnsOne(a => a.PrestamoId, p =>
            {
                p.Property(x => x.Value)
                    .HasColumnName("PrestamoId")
                    .IsRequired();
            });
            builder.OwnsOne(a => a.Fecha, f =>
            {
                f.Property(x => x.Value)
                    .HasColumnName("Fecha")
                    .IsRequired();
            });
            builder.OwnsOne(a => a.CoordinadorId, c =>
            {
                c.Property(x => x.Value)
                    .HasColumnName("CoordinadorId")
                    .IsRequired();
            });
            builder.OwnsOne(a => a.CoordinadorNombre, n =>
            {
                n.Property(x => x.Value)
                    .HasColumnName("CoordinadorNombre")
                    .HasMaxLength(100)
                    .IsRequired();
            });
            builder.OwnsOne(a => a.Accion, a =>
            {
                a.Property(x => x.Value)
                    .HasColumnName("Accion")
                    .HasMaxLength(50)
                    .IsRequired();
            });
        }
    }
}