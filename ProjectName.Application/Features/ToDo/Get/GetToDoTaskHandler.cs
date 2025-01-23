using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectName.Application.Commons.Data;
using ProjectName.Application.Commons.Responses;

namespace ProjectName.Application.Features.ToDo.Get
{
    public class GetToDoTaskHandler(IMapper mapper, IApplicationDbContext context) : IRequestHandler<GetToDoTaskQuery, ServiceResponse<GetToDoTask>>
    {
        public async Task<ServiceResponse<GetToDoTask>> Handle(GetToDoTaskQuery request, CancellationToken cancellationToken)
        {
            var item = await context.TodoItems.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (item == null)
                return ServiceResponse<GetToDoTask>.Failure("No Task found");

            var mapResponse = mapper.Map<GetToDoTask>(item);
            return ServiceResponse<GetToDoTask>.Success(mapResponse, "Task found");
        }
    }
}

