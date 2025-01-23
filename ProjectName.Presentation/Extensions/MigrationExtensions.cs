using Microsoft.EntityFrameworkCore;
using ProjectName.Infrastructure.Persistence;
namespace ProjectName.Presentation.Extensions;
public static partial class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        using ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();
    }
}

