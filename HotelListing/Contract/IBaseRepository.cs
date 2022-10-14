namespace HotelListing.Contract
{
    public interface IBaseRepository<Entity> where Entity : class
    {
        Task<Entity> GetAsync(int? entity);
        Task<List<Entity>> GetAllAsync();
        Task<Entity> AddAsync(Entity entity);
        Task<Entity?> DeleteAsync(int id);
        Task UpdateAsync(Entity entity);
        Task<bool> Exists(int id);
    }
}
