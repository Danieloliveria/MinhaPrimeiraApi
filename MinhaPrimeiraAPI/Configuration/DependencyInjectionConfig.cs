using Microsoft.Extensions.Options;
using MinhaPrimeiraAPI.Repositories;
using MinhaPrimeiraAPI.Repositories.Interfaces;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MinhaPrimeiraAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IParticipanteRepository, ParticipanteRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }
    }
}