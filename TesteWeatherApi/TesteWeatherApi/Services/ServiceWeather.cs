using AutoMapper;
using Newtonsoft.Json;
using TesteWeatherApi.Data.Context;
using TesteWeatherApi.Data.Models;
using TesteWeatherApi.Interfaces.Repositories;
using TesteWeatherApi.Interfaces.Services;
using TesteWeatherApi.ViewModels;

namespace TesteWeatherApi.Services
{
    public class ServiceWeather : IServiceWeather
    {
        private readonly IRepositoryWeather _repository;
        private readonly IMapper _mapper;
        public ServiceWeather(IMapper mapper, IRepositoryWeather repository)
        {
            _mapper= mapper;
            _repository= repository;
        }
        public async Task<TemperatureViewModel> GetTemperature(string city)
        {
            try
            {
                var data = await _repository.GetAll();
                var resultJson = await FetchWeatherDataFromApi(city);

                if (resultJson == null)
                    return null;

                var validatorCache = await _repository.GetValidator(_mapper.Map<BaseWeatherEntity>(resultJson));
                if (validatorCache != null)
                {
                    var cache = _mapper.Map<TemperatureViewModel>(validatorCache);
                    return cache;

                }

                var lastInsert = GetLastInsert(data, resultJson);

                if (lastInsert != null)
                {
                    return _mapper.Map<TemperatureViewModel>(lastInsert);
                }
                else
                {
                    resultJson = GenerateRandomIds(resultJson);
                    await _repository.Create(_mapper.Map<BaseWeatherEntity>(resultJson));
                    return _mapper.Map<TemperatureViewModel>(resultJson);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<BaseWeatherViewModel> FetchWeatherDataFromApi(string city)
        {
            var apiWeather = new HttpClient();
            var responseApi = await apiWeather.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=d542388594fb3e185a4d7bd8434e74b1");
            var resultJson = JsonConvert.DeserializeObject<BaseWeatherViewModel>(await responseApi.Content.ReadAsStringAsync());
            return resultJson;
        }

        private BaseWeatherViewModel GenerateRandomIds(BaseWeatherViewModel data)
        {
            var random = new Random();
            data.Id += random.Next(2, 1000000);
            data.Weather.FirstOrDefault().Id += random.Next(2, 1000000);
            data.Sys.Id += random.Next(2, 1000000);
            return data;
        }
        private BaseWeatherEntity GetLastInsert(IEnumerable<BaseWeatherEntity> data, BaseWeatherViewModel resultJson)
        {
            return data.LastOrDefault(w => w.Name == resultJson.Name && w.LastUpdate >= DateTime.Now.AddMinutes(-20));
        }
    }
}
