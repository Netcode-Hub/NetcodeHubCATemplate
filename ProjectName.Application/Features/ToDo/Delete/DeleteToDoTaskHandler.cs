using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectName.Application.Commons.Data;
using ProjectName.Application.Commons.Responses;
namespace ProjectName.Application.Features.ToDo.Delete
{
    public class DeleteToDoTaskHandler(IApplicationDbContext context) : IRequestHandler<DeleteToDoTaskCommand, ServiceResponse<Guid>>
    {
        public async Task<ServiceResponse<Guid>> Handle(DeleteToDoTaskCommand request, CancellationToken cancellationToken)
        {
            if (request.DeleteToDo.Id == Guid.Empty)
                return ServiceResponse<Guid>.Failure("Invalid Task provided");

            var item = await context.TodoItems.FirstOrDefaultAsync(x => x.Id == request.DeleteToDo.Id, cancellationToken: cancellationToken);
            if (item == null)
                return ServiceResponse<Guid>.Failure("Task not found");

            context.TodoItems.Remove(item);
            await context.SaveChangesAsync(cancellationToken);
            return ServiceResponse<Guid>.Success(Guid.Empty, "Task deleted");
        }
    }
}

