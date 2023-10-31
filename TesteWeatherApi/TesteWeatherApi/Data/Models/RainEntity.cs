using System.ComponentModel.DataAnnotations.Schema;
using TesteWeatherApi.Data.Context;

namespace TesteWeatherApi.Data.Models
{
    public class RainEntity
    {
        public int Id { get; set; }
        public BaseWeatherEntity BaseWeatherEntity { get; set; }
        public int BaseWeatherEntityId { get; set; }
        public float _1H { get; set; }
    }
}
