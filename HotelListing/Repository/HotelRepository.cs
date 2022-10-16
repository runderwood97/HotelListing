using HotelListing.Contract;
using HotelListing.Data;

namespace HotelListing.Repository
{
    public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(HotelListingDbContext context) : base(context)
        {
        }
    }
}
