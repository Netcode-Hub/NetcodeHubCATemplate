using AutoMapper;
using MediatR;
using ProjectName.Application.Commons.Data;
using ProjectName.Application.Commons.Responses;
using ProjectName.Domain.Entities;
namespace ProjectName.Application.Features.ToDo.Create
{
    public class CreateToDoTaskHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<CreateToDoTaskCommand, ServiceResponse<Guid>>
    {
        public async Task<ServiceResponse<Guid>> Handle(CreateToDoTaskCommand request, CancellationToken cancellationToken)
        {
            // Validation will be handled by the Behavior
            // Exception will be handled by the Behavior
            // Logging will be handled by the Behavior

            var mapDto = mapper.Map<ToDoTask>(request.CreateToDo);
            if (mapDto == null)
                return ServiceResponse<Guid>.Failure("Invalid request");

            context.TodoItems.Add(mapDto);
            await context.SaveChangesAsync(cancellationToken);
            return ServiceResponse<Guid>.Success(Guid.Empty, "Task created");
        }
    }
}
