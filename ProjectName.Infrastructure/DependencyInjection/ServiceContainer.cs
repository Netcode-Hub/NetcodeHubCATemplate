using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.Application.Commons.Data;
using ProjectName.Infrastructure.Persistence;
namespace ProjectName.Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config) =>
            services.AddDatabase(config).AddHealthChecks(config);
        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("ConnectionString");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));
            services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());
            return services;
        }
        private static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks().AddSqlite(configuration.GetConnectionString("ConnectionString")!);
            return services;
        }
    }
}
