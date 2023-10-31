using System.ComponentModel.DataAnnotations.Schema;
using TesteWeatherApi.Data.Context;

namespace TesteWeatherApi.Data.Models
{
    public class WeatherEntity
    {
        public BaseWeatherEntity BaseWeatherEntity { get; set; }
        public int BaseWeatherEntityId { get; set; }
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }




}
