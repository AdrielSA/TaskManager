using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManager.Infrastructure.Persistence.Configurations
{
    internal class TaskConfiguration : IEntityTypeConfiguration<Core.Entities.Task>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Task> builder)
        {
            builder.ToTable("Task");

            builder.HasKey(e => e.Id)
                   .HasName("PK_TASK");

            builder.Property(e => e.Description)
                .HasColumnName("Descripcion")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.CreationDate)
                .HasColumnName("FechaCreacion")
                .HasColumnType("datetime");

            builder.Property(e => e.Status)
                .HasColumnName("Estado")
                .HasMaxLength(10)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.Priority)
                .HasColumnName("Prioridad");
        }
    }
}
