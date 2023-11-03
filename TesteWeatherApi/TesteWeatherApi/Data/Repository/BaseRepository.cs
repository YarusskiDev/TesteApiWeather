using Microsoft.EntityFrameworkCore;
using TesteWeatherApi.Data.Context;
using TesteWeatherApi.Interfaces.Repositories;

namespace TesteWeatherApi.Data.Repository
{
    public  class BaseRepository<Entity>:IBaseRepository<Entity> where Entity : class
    {
        public readonly ContextEntity _context;

        public BaseRepository(ContextEntity context)
        {
            _context = context;
        }

        public async Task<Entity> Create(Entity entity)
        {
            _context.Set<Entity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _context.Set<Entity>().FindAsync(id);
            _context.Set<Entity>().Remove(item);
            await _context.SaveChangesAsync();

            if (item != null)
            {
                return true;
            }
            return false;
        }

        public async Task<Entity> Get(int id)
        {
            return await _context.Set<Entity>().FindAsync(id);
        }

        public async Task<List<Entity>> GetAll()
        {
            return await _context.Set<Entity>().ToListAsync();
        }

        public async Task<Entity> Update(Entity entity, int id)
        {
            var exist = await _context.Set<Entity>().FindAsync(id);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            return entity;
        }
    }
}
