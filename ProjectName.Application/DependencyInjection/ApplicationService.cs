using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.Application.Commons.Behaviors;
namespace ProjectName.Application.DependencyInjection
{
    public static class ApplicationService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(ApplicationService).Assembly, includeInternalTypes: true);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(ApplicationService).Assembly);
                config.AddOpenBehavior(typeof(LoggingBehavior<,>));
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            return services;
        }
    }
}
