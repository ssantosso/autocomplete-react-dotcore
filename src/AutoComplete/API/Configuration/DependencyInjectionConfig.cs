
using Autocomplete.Business.Interface;
using Autocomplete.Business.Notificacoes;
using Autocomplete.Business.Repository;
using Autocomplete.Data.Contexto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
namespace Autocomplete.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<INotificador, Notificador>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICityRepository, CityRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            return services;
        }
    }
}
