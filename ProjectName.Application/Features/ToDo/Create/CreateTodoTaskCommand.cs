using MediatR;
using ProjectName.Application.Commons.Responses;
namespace ProjectName.Application.Features.ToDo.Create
{
    public record CreateToDoTaskCommand(CreateToDoTask CreateToDo) : IRequest<ServiceResponse<Guid>>;
}
