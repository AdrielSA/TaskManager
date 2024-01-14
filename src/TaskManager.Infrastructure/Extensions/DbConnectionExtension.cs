using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Infrastructure.Persistence.Contexts;

namespace TaskManager.Infrastructure.Extensions
{
    public static class DbConnectionExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<TaskManagerDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("LocalDB")));
    }
}
