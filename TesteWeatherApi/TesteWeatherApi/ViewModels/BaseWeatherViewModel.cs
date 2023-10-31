using TesteWeatherApi.Data.Models;

namespace TesteWeatherApi.ViewModels
{
    public class BaseWeatherViewModel
    {
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Rain Rain { get; set; }
        public Clouds Clouds { get; set; }
        public int Dt { get; set; }
        public Sys Sys { get; set; }
        public string Name { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public int Cod { get; set; }

        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }



}