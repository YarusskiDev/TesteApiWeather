using TesteWeatherApi.Data.Models;
using TesteWeatherApi.ViewModels;

namespace TesteWeatherApi.Interfaces.Services
{
    public interface IServiceWeather
    {
        Task<TemperatureViewModel> GetTemperature(string city);
    }
}
