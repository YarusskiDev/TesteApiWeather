using TesteWeatherApi.Data.Models;
using TesteWeatherApi.ViewModels;

namespace TesteWeatherApi.Interfaces.Repositories
{
    public interface IRepositoryWeather : IBaseRepository<BaseWeatherEntity>
    {
        Task<BaseWeatherEntity> GetValidator(string city);
        Task<bool> CheckCity(string city);
    }
}
