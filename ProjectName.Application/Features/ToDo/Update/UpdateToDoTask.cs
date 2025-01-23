namespace ProjectName.Application.Features.ToDo.Update
{
    public record UpdateToDoTask : ToDoTaskBase
    {
        public Guid Id { get; set; }
    }
}

