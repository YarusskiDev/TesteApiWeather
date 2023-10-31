using Microsoft.AspNetCore.Mvc;
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
        public WeatherController(IServiceWeather service)
        {
            _service= service;
        }
       
        [HttpGet("{city}")]
        public async Task<IActionResult> GetTemperature(string city)
        {
            var result = await _service.GetTemperature(city);

            if (result != null)
                return Ok(result);
            else
                return BadRequest();

        }

       
    }
}
