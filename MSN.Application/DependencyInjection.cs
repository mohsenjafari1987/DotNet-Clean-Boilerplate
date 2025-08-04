using System.Reflection;
using MSN.Framework.Abstractions;
using MSN.Framework.CQRS;
using MSN.Framework.Pipeline;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MSN.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register all MediatR handlers (command & query)
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(Application.DependencyInjection).Assembly);
            });


            // Register CQRS processors (optional wrappers for ISender)
            services.AddScoped<ICommandProcessor, CommandProcessor>();
            services.AddScoped<IQueryProcessor, QueryProcessor>();

            // Register all FluentValidation validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Register MediatR pipeline behaviors
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehavior<,>));

            return services;
        }
    }
}
