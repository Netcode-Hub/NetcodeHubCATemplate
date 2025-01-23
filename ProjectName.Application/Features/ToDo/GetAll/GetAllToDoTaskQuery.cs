using MediatR;
using ProjectName.Application.Commons.Responses;
namespace ProjectName.Application.Features.ToDo.GetAll
{
    public record GetAllToDoTaskQuery : IRequest<ServiceResponse<IEnumerable<GetToDoTask>>>;
}
