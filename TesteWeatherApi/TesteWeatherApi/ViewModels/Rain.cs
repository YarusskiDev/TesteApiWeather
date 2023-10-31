using Newtonsoft.Json;
using TesteWeatherApi.Data.Context;

namespace TesteWeatherApi.ViewModels
{
    public class Rain
    {
        [JsonProperty(PropertyName = "_1h")]
        public float _1H { get; set; }
    }




}
