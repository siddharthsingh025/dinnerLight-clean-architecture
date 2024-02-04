using dinnerLight.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace dinnerLight.Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service ){
        service.AddScoped<IAuthenticationService,AuthenticationService>();

        return service;
    }

}