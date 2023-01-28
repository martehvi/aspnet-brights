using System.Reflection;
using Conduit.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Conduit.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
            .AddMediatR(Assembly.GetExecutingAssembly())
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(QueryBehavior<,>))
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}