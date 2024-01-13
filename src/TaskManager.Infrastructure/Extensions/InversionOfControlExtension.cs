using Microsoft.Extensions.DependencyInjection;
using TaskManager.Core.Interfaces.Repositories;
using TaskManager.Core.Interfaces.Services;
using TaskManager.Core.Services;
using TaskManager.Infrastructure.Repositories;

namespace TaskManager.Infrastructure.Extensions
{
    public static class InversionOfControlExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Services
            services.AddScoped<ITaskService, TaskService>();

            return services;
        }
    }
}
