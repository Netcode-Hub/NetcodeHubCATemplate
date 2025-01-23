using FluentValidation;

namespace ProjectName.Application.Features.ToDo.Delete
{
    public class DeleteToDoTaskValidator : AbstractValidator<DeleteToDoTask>
    {
        public DeleteToDoTaskValidator()
        {
            RuleFor(x => x.Id)
          .NotEmpty().WithMessage("ID is required.");
        }
    }
}

