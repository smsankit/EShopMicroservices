

using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behaviours;

public class LoggingBehaviour<TRequest, TResponse>
    (ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation("[START] Handle request={request} - Response={Response} - Requestdata = {RequestData}",
            typeof(TRequest).Name, typeof(TResponse).Name, request);

        var timer = new Stopwatch();
        timer.Start();

        var response = await next();

        timer.Stop();
        if(timer.Elapsed.Seconds > 3)
        {
            logger.LogWarning("[PERFORMANCE] the request {Request} took {TimeTaken}",
                typeof(TRequest).Name, timer.Elapsed.Seconds);
        }

        logger.LogInformation("[END] Handled {REquest} with {Response}",
            typeof(TRequest), typeof(TResponse));

        return response;
    }
}
