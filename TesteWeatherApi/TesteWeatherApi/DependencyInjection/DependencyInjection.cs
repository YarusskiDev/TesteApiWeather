using TesteWeatherApi.Data.Context;
using TesteWeatherApi.Data.Repository;
using TesteWeatherApi.Interfaces.Repositories;
using TesteWeatherApi.Interfaces.Services;
using TesteWeatherApi.Services;

namespace TesteWeatherApi.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection Injection(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWeather,WeatherRepository>();
            services.AddScoped<IServiceWeather, ServiceWeather>();
            services.AddScoped<ContextEntity>();
            return services;

        }
    }    
}   
