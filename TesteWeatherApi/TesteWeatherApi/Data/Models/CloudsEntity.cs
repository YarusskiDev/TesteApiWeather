using System.ComponentModel.DataAnnotations.Schema;
using TesteWeatherApi.Data.Context;

namespace TesteWeatherApi.Data.Models
{
    public class CloudsEntity
    {
        public int Id { get; set; }
        public BaseWeatherEntity BaseWeatherEntity { get; set; }
        public int BaseWeatherEntityId { get; set; }
        public int All { get; set; }
    }




}
