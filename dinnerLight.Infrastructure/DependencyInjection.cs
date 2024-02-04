using dinnerLight.Application.Common.Interfaces.Authentication;
using dinnerLight.Application.Common.Interfaces.Services;
using dinnerLight.Infrastructure.Authentication;
using dinnerLight.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dinnerLight.Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, ConfigurationManager configuration)
    {
        service.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        service.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();
        service.AddSingleton<IDateTimeProvider , DateTimeProvider>();
        return service;
    }

}