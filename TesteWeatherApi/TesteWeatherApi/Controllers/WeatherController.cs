using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using TesteWeatherApi.Interfaces.Services;
using TesteWeatherApi.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteWeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        readonly IServiceWeather _service;
        private readonly IMemoryCache _cache;
        public WeatherController(IServiceWeather service, IMemoryCache cache)
        {
            _service = service;
            _cache = cache;
        }

        /// <summary>
        /// Busca temperatura da cidade informada. ENDPOINT IMPLEMENTADO MEMORYCACHE
        /// </summary>
        /// <param name="city">Nome da cidade</param>
        /// <returns>min,max e temp</returns>
        [HttpGet("{city}")]
        public async Task<ActionResult<TemperatureViewModel>> GetTemperatureMemoryCache(string city)
        {
            try
            {
                if (_cache.TryGetValue(city, out TemperatureViewModel? cachedData) && cachedData != null)
                    return Ok(cachedData);

                var result = await _service.GetTemperature(city);
                if (result != null)
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                    };

                    _cache.Set(city, result, cacheEntryOptions);
                    return Ok(result);
                }
                else
                    return BadRequest();
            }
            catch 
            {
                return NotFound();
            }
        }

        /// <summary>
        /// ENDPOINT IMPLEMENTADO COM RESPONSECACHE PARA BARRAR NO HTTP
        /// </summary>
        /// <param name = "city" ></ param >
        /// < returns ></ returns >
        //[HttpGet("{city}")]
        //[ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        //public async Task<ActionResult<TemperatureViewModel>> GetTemperatureResponseCache(string city)
        //{
        //    try
        //    {
        //        if (_cache.TryGetValue(city, out TemperatureViewModel? cachedData) && cachedData != null)
        //            return Ok(cachedData);

        //        var result = await _service.GetTemperature(city);
        //        if (result != null)
        //        {
        //            var cacheEntryOptions = new MemoryCacheEntryOptions
        //            {
        //                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
        //            };

        //            _cache.Set(city, result, cacheEntryOptions);
        //            return Ok(result);
        //        }
        //        else
        //            return BadRequest();
        //    }
        //    catch
        //    {
        //        return NotFound();
        //    }
        //}


        /// <summary>
        /// ENDPOINT IMPLEMENTADO SEM CACHE
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        //[HttpGet("{city}")]
        //public async Task<ActionResult<TemperatureViewModel>> GetTemperature(string city)
        //{
        //    try
        //    {
        //        if (_cache.TryGetValue(city, out TemperatureViewModel? cachedData) && cachedData != null)
        //            return Ok(cachedData);

        //        var result = await _service.GetTemperature(city);
        //        if (result != null)
        //        {
        //            var cacheEntryOptions = new MemoryCacheEntryOptions
        //            {
        //                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
        //            };

        //            _cache.Set(city, result, cacheEntryOptions);
        //            return Ok(result);
        //        }
        //        else
        //            return BadRequest();
        //    }
        //    catch
        //    {
        //        return NotFound();
        //    }
        //}



    }
}
