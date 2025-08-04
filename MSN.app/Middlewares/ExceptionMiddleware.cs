using System.Net;
using System.Text.Json;
using MSN.Domain.Exceptions; // If you have a custom DomainException
using FluentResults;
using FluentValidation;

public class ExceptionMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context); // Continue pipeline
        }
        catch (ValidationException ex)
        {
            _logger.LogWarning(ex, "Validation failed");

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";

            var result = Result.Fail(
                ex.Errors.Select(err => new Error(err.ErrorMessage))
            );

            await context.Response.WriteAsync(JsonSerializer.Serialize(result));
        }
        catch (DomainException ex)
        {
            _logger.LogWarning(ex, "Business rule violation");

            context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
            context.Response.ContentType = "application/json";

            var result = Result.Fail(new Error(ex.Message));

            await context.Response.WriteAsync(JsonSerializer.Serialize(result));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var result = Result.Fail("An unexpected error occurred.");

            await context.Response.WriteAsync(JsonSerializer.Serialize(result));
        }
    }
}
