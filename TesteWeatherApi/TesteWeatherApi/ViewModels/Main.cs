using Newtonsoft.Json;
using TesteWeatherApi.Data.Context;

namespace TesteWeatherApi.ViewModels
{
    public class Main
    {
        [JsonProperty(PropertyName = "temp")]
        public float Temp { get; set; }

        [JsonProperty(PropertyName = "feels_like")]
        public float Feels_like { get; set; }

        [JsonProperty(PropertyName = "temp_min")]
        public float Temp_min { get; set; }

        [JsonProperty(PropertyName = "temp_max")]
        public float Temp_max { get; set; }

        [JsonProperty(PropertyName = "pressure")]
        public int Rressure { get; set; }

        [JsonProperty(PropertyName = "humidity")]
        public int Humidity { get; set; }
    }




}
