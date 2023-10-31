using Newtonsoft.Json;
using TesteWeatherApi.Data.Context;

namespace TesteWeatherApi.ViewModels
{
    public class Coord
    {

        [JsonProperty(PropertyName = "lon")]
        public float Lon { get; set; }

        [JsonProperty(PropertyName = "lat")]
        public float Lat { get; set; }
    }




}
