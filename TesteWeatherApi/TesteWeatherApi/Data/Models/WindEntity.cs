using TesteWeatherApi.Data.Context;

namespace TesteWeatherApi.Data.Models
{
    public class WindEntity
    {
        public int Id { get; set; }
        public BaseWeatherEntity BaseWeatherEntity { get; set; }
        public int BaseWeatherEntityId { get; set; }
        public float Speed { get; set; }
        public int Deg { get; set; }
    }




}
