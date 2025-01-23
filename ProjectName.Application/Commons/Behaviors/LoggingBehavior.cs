using MediatR;
using Serilog;
namespace ProjectName.Application.Commons.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Log.Information("Handling {RequestName} with data: {@Request}", typeof(TRequest).Name, request);

            var response = await next();

            Log.Information("Handled {RequestName} with response: {@Response}", typeof(TRequest).Name, response);

            return response;
        }
    }
}
