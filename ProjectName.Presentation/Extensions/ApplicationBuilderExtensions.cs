using Scalar.AspNetCore;
namespace ProjectName.Presentation.Extensions;
public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseScalar(this WebApplication app)
    {
        app.MapScalarApiReference();
        return app;
    }
}


