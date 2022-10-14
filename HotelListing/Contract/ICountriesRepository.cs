using HotelListing.Data;

namespace HotelListing.Contract
{
    public interface ICountriesRepository : IBaseRepository<Country>
    {
        Task<Country?> GetDetails(int? id);
    }
}
