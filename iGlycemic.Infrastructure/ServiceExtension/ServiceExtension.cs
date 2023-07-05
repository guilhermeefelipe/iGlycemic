using iGlycemic.Core.Interfaces;
using iGlycemic.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace iGlycemic.Infrastructure.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContextClass>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            return services;
        }
    }
}
