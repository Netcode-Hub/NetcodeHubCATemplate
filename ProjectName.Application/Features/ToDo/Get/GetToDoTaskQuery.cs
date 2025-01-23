using MediatR;
using ProjectName.Application.Commons.Responses;

namespace ProjectName.Application.Features.ToDo.Get
{
    public record GetToDoTaskQuery(Guid Id) : IRequest<ServiceResponse<GetToDoTask>>;
}

