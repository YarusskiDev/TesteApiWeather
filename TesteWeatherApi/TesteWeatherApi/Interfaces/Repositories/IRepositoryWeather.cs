using TesteWeatherApi.Data.Models;
using TesteWeatherApi.ViewModels;

namespace TesteWeatherApi.Interfaces.Repositories
{
    public interface IRepositoryWeather : IBaseRepository<BaseWeatherEntity>
    {
        Task<BaseWeatherEntity> GetValidator(BaseWeatherEntity entity);
    }
}
