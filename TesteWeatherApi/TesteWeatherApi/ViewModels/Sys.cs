using Newtonsoft.Json;
using TesteWeatherApi.Data.Context;

namespace TesteWeatherApi.ViewModels
{
    public class Sys
    {
        [JsonProperty(PropertyName = "type")]
        public int Type { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "sunrise")]
        public int Sunrise { get; set; }

        [JsonProperty(PropertyName = "sunset")]
        public int Sunset { get; set; }
    }




}
