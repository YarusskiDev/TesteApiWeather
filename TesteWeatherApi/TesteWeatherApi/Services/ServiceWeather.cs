using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<TemperatureViewModel> GetTemperature(string city)
        {
            try
            {
                var alreadyExistCity = await _repository.CheckCity(city);
                if (!alreadyExistCity)
                {
                    var resultJson = await FetchWeatherDataFromApi(city);
                    return _mapper.Map<TemperatureViewModel>(await _repository.Create(_mapper.Map<BaseWeatherEntity>(resultJson)));
                }

                var validatorCache = await _repository.GetValidator(city);
                if (validatorCache != null)
                {
                    var cache = _mapper.Map<TemperatureViewModel>(validatorCache);
                    return cache;
                }
                else
                {
                    var resultApi = await FetchWeatherDataFromApi(city);
                    if (resultApi == null)
                        throw new Exception();
                    await _repository.Update(_mapper.Map<BaseWeatherEntity>(resultApi),resultApi.Id);
                    return _mapper.Map<TemperatureViewModel>(resultApi);
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
            var randomId = new Random();
            resultJson.Weather.FirstOrDefault().Id += randomId.Next(2, 1000000);
            resultJson.Sys.Id += randomId.Next(2, 1000000);
            return resultJson;
        }
    }
}
