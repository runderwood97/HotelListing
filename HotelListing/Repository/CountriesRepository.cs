using HotelListing.Contract;
using HotelListing.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Repository
{
    public class CountriesRepository : BaseRepository<Country> , ICountriesRepository
    {
        private readonly HotelListingDbContext _context;

        public CountriesRepository(HotelListingDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Country?> GetDetails(int? id)
        {
            var country = await _context.Countries.Include(query => query.Hotels)
                            .FirstOrDefaultAsync(query => query.Id == id);

            return country;
        }
    }
}
