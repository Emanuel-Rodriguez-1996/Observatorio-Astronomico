using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obligatorio.LogicaNegocio.Entidades.EnUsuarios;

namespace Obligatorio.Infraestructura.AccesoDatos.EF.Confg
{
    public class UserConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.OwnsOne(usuario => usuario.Nombre, VOName =>
            {
                VOName.Property(n => n.Value).HasColumnName("Nombre").IsRequired();
            });
            builder.OwnsOne(usuario => usuario.Direccion, VOAddress =>
            {
                VOAddress.Property(d => d.Value).HasColumnName("Direccion").IsRequired(false);
            });
            builder.OwnsOne(usuario => usuario.Telefono, VOPhone =>
            {
                VOPhone.Property(t => t.Value).HasColumnName("Telefono");
            });
            builder.OwnsOne(usuario => usuario.Email, VOEmail =>
            {
                VOEmail.Property(e => e.Value).HasColumnName("Email").IsRequired();
            });
            builder.OwnsOne(usuario => usuario.UserName, VOUserName =>
            {
                VOUserName.Property(u => u.Value).HasColumnName("UserName").IsRequired();
            });
            builder.OwnsOne(usuario => usuario.Password, VOPassword =>
            {
                VOPassword.Property(p => p.Value).HasColumnName("Password").IsRequired();
            });
            builder.OwnsOne(usuario => usuario.Rol, VORol =>
            {
                VORol.Property(r => r.Value).HasColumnName("Rol").IsRequired();
            });
        }
    }
}
