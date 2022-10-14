using HotelListing.Contract;
using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace HotelListing.Repository
{
    public class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : class
    {
        private readonly HotelListingDbContext _context;

        public BaseRepository(HotelListingDbContext context)
        {
            this._context = context;
        }

        // Based off the 'Entity' or 'Class' either 'Country' or 'Hotel' Set<Entity>() will map the data to the correct table
        // This is determined by the Class that is passed into the BaseRepository() and the Data.HotelListingDbContext file
        // The public 'DbSet's will determine the mapping to the correct table 
        public async Task<Entity> AddAsync(Entity entity)
        {
            await _context.Set<Entity>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        // Based off the 'Entity' or 'Class' either 'Country' or 'Hotel' Set<Entity>() will map the data to the correct table
        // This is determined by the Class that is passed into the BaseRepository() and the Data.HotelListingDbContext file
        // The public 'DbSet's will determine the mapping to the correct table 
        public async Task<Entity?> DeleteAsync(int id)
        {
            // GetAsync is calling the public method GetAsync that is delcared in this class below
            var entity = await GetAsync(id);

            if (entity != null)
            {
                _context.Set<Entity>().Remove(entity);
                await _context.SaveChangesAsync();
            }

            return entity;
        }

        // Based off the 'Entity' or 'Class' either 'Country' or 'Hotel' Set<Entity>() will map the data to the correct table
        // This is determined by the Class that is passed into the BaseRepository() and the Data.HotelListingDbContext file
        // The public 'DbSet's will determine the mapping to the correct table 
        public async Task<bool> Exists(int id)
        {
            // GetAsync is calling the public method GetAsync that is delcared in this class below
            var entity = await GetAsync(id);
            return entity != null;
        }

        // Based off the 'Entity' or 'Class' either 'Country' or 'Hotel' Set<Entity>() will map the data to the correct table
        // This is determined by the Class that is passed into the BaseRepository() and the Data.HotelListingDbContext file
        // The public 'DbSet's will determine the mapping to the correct table 
        public async Task<List<Entity>> GetAllAsync()
        {
            return await _context.Set<Entity>().ToListAsync();
        }

        // Based off the 'Entity' or 'Class' either 'Country' or 'Hotel' Set<Entity>() will map the data to the correct table
        // This is determined by the Class that is passed into the BaseRepository() and the Data.HotelListingDbContext file
        // The public 'DbSet's will determine the mapping to the correct table 
        public async Task<Entity> GetAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }

            return await _context.Set<Entity>().FindAsync(id);
        }

        // Based off the 'Entity' or 'Class' either 'Country' or 'Hotel' Set<Entity>() will map the data to the correct table
        // This is determined by the Class that is passed into the BaseRepository() and the Data.HotelListingDbContext file
        // The public 'DbSet's will determine the mapping to the correct table 
        public async Task UpdateAsync(Entity entity)
        {
            _context.Set<Entity>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
