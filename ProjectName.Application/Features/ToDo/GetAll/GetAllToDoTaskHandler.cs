using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectName.Application.Commons.Data;
using ProjectName.Application.Commons.Responses;
namespace ProjectName.Application.Features.ToDo.GetAll
{
    public class GetAllToDoTaskHandler(IApplicationDbContext context) : IRequestHandler<GetAllToDoTaskQuery, ServiceResponse<IEnumerable<GetToDoTask>>>
    {
        public async Task<ServiceResponse<IEnumerable<GetToDoTask>>> Handle(GetAllToDoTaskQuery request, CancellationToken cancellationToken)
        {
            // better with performace
            var getTasks = await context.TodoItems
                .AsNoTracking()
                .Select(x => new GetToDoTask
                {
                    Description = x.Description,
                    Title = x.Title,
                    DueDate = x.DueDate,
                    IsCompleted = x.IsCompleted,
                    Priority = x.Priority.ToString(),
                })
                .ToListAsync(cancellationToken);

            return getTasks.Count > 0
                ? ServiceResponse<IEnumerable<GetToDoTask>>.Success(getTasks, "Tasks found")
                : new ServiceResponse<IEnumerable<GetToDoTask>>([], true, "Null");


            // than this
            //var items = await context.TodoItems.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
            //if (items.Count != 0)
            //{
            //    var getTasks = items.Select(x => new GetToDoTask()
            //    {
            //        Description = x.Description,
            //        Title = x.Title,
            //        DueDate = x.DueDate,
            //        IsCompleted = x.IsCompleted,
            //        Priority = x.Priority.ToString(),
            //    });
            //    return ServiceResponse<IEnumerable<GetToDoTask>>.Success(getTasks, "Tasks found");
            //}
            //return new ServiceResponse<IEnumerable<GetToDoTask>>([], true, "Null");

        }
    }
}
