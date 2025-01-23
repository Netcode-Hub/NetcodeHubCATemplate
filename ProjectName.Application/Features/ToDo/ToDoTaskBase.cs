namespace ProjectName.Application.Features.ToDo
{
    // use abstract so this base record can't be instantiated
    public abstract record ToDoTaskBase
    {
        public string Title { get; init; }
        public string Description { get; init; }
        public string Priority { get; init; }
        public DateTime DueDate { get; init; }
        public bool IsCompleted { get; init; }
    }
}

