using System.ComponentModel.DataAnnotations.Schema;
using TesteWeatherApi.Data.Context;

namespace TesteWeatherApi.Data.Models
{
    public class MainEntity
    {
        public int Id { get; set; }
        public BaseWeatherEntity BaseWeatherEntity { get; set; }
        public int BaseWeatherEntityId { get; set; }
        public float Temp { get; set; }
        public float Feels_like { get; set; }
        public float Temp_min { get; set; }
        public float Temp_max { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }




}
