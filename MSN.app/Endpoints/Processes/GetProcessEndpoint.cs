using MSN.Contract.Processes.Queries;
using MSN.Contract.Processes.Responces;
using MSN.Framework.Abstractions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace MSN.app.Endpoints.Processes
{
    public static class GetProcessEndpoint
    {
        internal static IEndpointRouteBuilder MapGetProcessEndpoint(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/GetProcessById", GetProcess)
                .WithTags("Process")
                .Produces<GetProcessResponse>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status401Unauthorized)
                .WithName("GetProcess")
                .WithDisplayName("GetProcess");

            return endpoints;
        }

        private static async Task<IResult> GetProcess(
            [FromQuery] int processId,
            IQueryProcessor queryProcessor,
            CancellationToken cancellationToken)
        {            

            var query = new GetProcessQuery(processId);
            var result = await queryProcessor.SendAsync(query, cancellationToken);

            if (result.IsFailed)
                return Results.NotFound(result.Errors.FirstOrDefault());

            return Results.Ok(result.Value);

        }
    }
}
