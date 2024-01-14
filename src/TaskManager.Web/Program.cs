using TaskManager.Infrastructure.Extensions;
using TaskManager.Web.Middlewares.Filters;

namespace TaskManager.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddControllersWithViews(options 
                => options.Filters.Add(typeof(ModelStateValidationFilter)));
            builder.Services.AddDatabase(builder.Configuration);
            builder.Services.AddDependencies();
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Task}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
