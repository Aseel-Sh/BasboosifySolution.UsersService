using Basboosify.Core.ServiceContracts;
using Basboosify.Core.Services;
using Basboosify.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Basboosify.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Extensions method to add core services to the dependency injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        //TO DO: Add services to the IoC container
        //Core services often include data access, caching and other low level components

        services.AddTransient<IUserService, UserService>();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

        return services;
    }
}

