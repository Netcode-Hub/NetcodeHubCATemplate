
using ProjectName.Application.Features.ToDo.Create;
using ProjectName.Domain.Entities;
using ProjectName.Infrastructure.Persistence;
using ProjectName.Presentation;
using System.Reflection;

namespace ArchitectureTest
{
    public abstract class BaseTest
    {
        protected static readonly Assembly DomainAssembly = typeof(ToDoTask).Assembly;
        protected static readonly Assembly ApplicationAssembly = typeof(CreateToDoTaskCommand).Assembly;
        protected static readonly Assembly InfrastructureAssembly = typeof(ApplicationDbContext).Assembly;
        protected static readonly Assembly PresentationAssembly = typeof(Program).Assembly;
    }
}
