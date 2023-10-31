using System.ComponentModel.DataAnnotations.Schema;
using TesteWeatherApi.Data.Context;

namespace TesteWeatherApi.Data.Models
{
    public class SysEntity
    {
        public BaseWeatherEntity BaseWeatherEntity { get; set; }
        public int BaseWeatherEntityId { get; set; }
        public int Type { get; set; }
        public int Id { get; set; }
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }




}
