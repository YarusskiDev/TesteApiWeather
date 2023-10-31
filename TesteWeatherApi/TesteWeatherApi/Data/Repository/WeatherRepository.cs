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

        public async Task<BaseWeatherEntity> GetValidator(BaseWeatherEntity entity)
        {
            var now = DateTime.Now;
            var twentyMinutesAgo = now.AddMinutes(-20);
            var resultQuery = await (from b in _context.BaseWeather.Include(w => w.Weather)
                                     where b.Name == entity.Name && b.LastUpdate >= twentyMinutesAgo
                              select b).FirstOrDefaultAsync();
            return resultQuery;
        }
    }
}
