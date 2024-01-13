using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace TaskManager.Infrastructure.Persistence.Contexts;

public partial class TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : DbContext(options)
{
    public virtual DbSet<Core.Entities.Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
