using Microsoft.EntityFrameworkCore;
using TesteWeatherApi.Data.Context;
using TesteWeatherApi.Data.Models;
using TesteWeatherApi.Interfaces.Repositories;
using TesteWeatherApi.ViewModels;

namespace TesteWeatherApi.Data.Repository
{
    public class WeatherRepository : BaseRepository<BaseWeatherEntity>,IRepositoryWeather
    {
        private readonly ContextEntity _context;
        public WeatherRepository(ContextEntity context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckCity(string city)
        {
            var exist = await _context.BaseWeather.Where(c => c.Name == city.ToLower()).FirstOrDefaultAsync();
            if (exist != null)
                return true;
            else
                return false;          
        }

        public async Task<BaseWeatherEntity> GetValidator(string city)
        {
            var now = DateTime.Now;
            var twentyMinutesAgo = now.AddMinutes(-20);
            var resultQuery = await (from b in _context.BaseWeather.Include(m => m.Main)
                                     where b.Name == city && b.LastUpdate >= twentyMinutesAgo
                              select b).FirstOrDefaultAsync();
            return resultQuery;
        }
    }
}
