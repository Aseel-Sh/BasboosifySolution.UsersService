using Basboosify.Core.RepositoryContracts;
using Basboosify.Infrastructure.DbContext;
using Basboosify.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Basboosify.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Extensions method to add infrastructure services to the dependency injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        //TO DO: Add services to the IoC container
        //Infrastructure services often include data access, caching and other low level components
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<DapperDbContext>();
        return services;
    }
}

