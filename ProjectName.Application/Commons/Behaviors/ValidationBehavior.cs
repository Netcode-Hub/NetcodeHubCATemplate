using FluentValidation;
using MediatR;
using Serilog;
namespace ProjectName.Application.Commons.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) :
        IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators = validators;
        public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();
            if (failures.Count != 0)
            {
                Log.Error($"Validation Errors: {failures}");
                throw new ValidationException(failures);
            }
            Log.Information("Model validation passed");
            return await next();
        }
    }
}
