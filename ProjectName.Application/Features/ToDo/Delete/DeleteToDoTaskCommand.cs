using MediatR;
using ProjectName.Application.Commons.Responses;
namespace ProjectName.Application.Features.ToDo.Delete
{
    public record DeleteToDoTaskCommand(DeleteToDoTask DeleteToDo) : IRequest<ServiceResponse<Guid>>;
}

