using ProjectName.Presentation.Excetions;
using ProjectName.Presentation.Extensions;
namespace ProjectName.Presentation.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddScalarWithAuth();
            services.AddControllers();
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();
            return services;
        }

        public static IApplicationBuilder UsePresentation(this WebApplication app)
        {
            app.UseScalar();
            return app;
        }
    }
}
