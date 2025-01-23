using MediatR;
using ProjectName.Application.Commons.Responses;
namespace ProjectName.Application.Features.ToDo.Update
{
    public record UpdateToDoTaskCommand(UpdateToDoTask UpdateToDo) : IRequest<ServiceResponse<Guid>>;
}
