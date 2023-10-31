using TesteWeatherApi.Data.Models;
using TesteWeatherApi.ViewModels;

namespace TesteWeatherApi.Data.Models
{

    public class BaseWeatherEntity
    {
        public CoordEntity Coord { get; set; }
        public List<WeatherEntity> Weather { get; set; }
        public string Base { get; set; }
        public MainEntity Main { get; set; }
        public int Visibility { get; set; }
        public WindEntity Wind { get; set; }
        public RainEntity Rain { get; set; }
        public CloudsEntity Clouds { get; set; }
        public int Dt { get; set; }
        public SysEntity Sys { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Name { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public int Cod { get; set; }
    }
}