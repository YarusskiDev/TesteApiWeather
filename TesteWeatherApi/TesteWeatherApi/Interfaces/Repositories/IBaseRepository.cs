namespace TesteWeatherApi.Interfaces.Repositories
{
    public interface IBaseRepository<Entity>
    {
        Task<Entity> Get(int id);
        Task<Entity> Update(Entity entity, int id);
        Task<bool> Delete(int id);
        Task<Entity> Create(Entity entity);
        Task<List<Entity>> GetAll();


    }
}
