using Newtonsoft.Json;

namespace TesteWeatherApi.ViewModels
{
    public class Clouds
    {
        [JsonProperty(PropertyName = "all")]
        public int All { get; set; }
    }




}
