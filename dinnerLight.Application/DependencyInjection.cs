using dinnerLight.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace dinnerLight.Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplication(this IServiceCollection service ){
        service.AddScoped<IAuthenticationService,AuthenticationService>();

        return service;
    }

}