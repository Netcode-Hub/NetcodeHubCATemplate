using AutoMapper;
using MediatR;
using ProjectName.Application.Commons.Data;
using ProjectName.Application.Commons.Responses;
using ProjectName.Application.Features.ToDo.Update;
using ProjectName.Domain.Entities;

public class UpdateToDoTaskHandler(IMapper mapper, IApplicationDbContext context) : IRequestHandler<UpdateToDoTaskCommand, ServiceResponse<Guid>>
{
    public async Task<ServiceResponse<Guid>> Handle(UpdateToDoTaskCommand request, CancellationToken cancellationToken)
    {
        // Validation will be handled by the Behavior
        // Exception will be handled by the Behavior
        // Logging will be handled by the Behavior

        var mapDto = mapper.Map<ToDoTask>(request.UpdateToDo);
        if (mapDto == null)
            return ServiceResponse<Guid>.Failure("Invalid request");

        context.TodoItems.Update(mapDto);
        await context.SaveChangesAsync(cancellationToken);
        return ServiceResponse<Guid>.Success(Guid.Empty, "Task updated");
    }
}
