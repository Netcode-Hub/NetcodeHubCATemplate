using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProjectName.Domain.Entities;
namespace ProjectName.Application.Commons.Data
{
    public interface IApplicationDbContext
    {
        DbSet<ToDoTask> TodoItems { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
